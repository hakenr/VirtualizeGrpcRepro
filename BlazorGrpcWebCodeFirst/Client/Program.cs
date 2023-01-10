using BlazorGrpcWebCodeFirst.Client;
using BlazorGrpcWebCodeFirst.Shared;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProtoBuf.Grpc.ClientFactory;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddTransient<GrpcWebHandler>(provider => new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler()));
builder.Services.AddTransient<CancellationWorkaroundGrpcClientInterceptor>();
builder.Services.AddCodeFirstGrpcClient<IMyService>(o => o.Address = new Uri(builder.HostEnvironment.BaseAddress))
	.ConfigurePrimaryHttpMessageHandler<GrpcWebHandler>()
	.AddInterceptor<CancellationWorkaroundGrpcClientInterceptor>();


await builder.Build().RunAsync();
