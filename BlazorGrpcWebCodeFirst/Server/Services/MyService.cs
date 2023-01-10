using System.Globalization;
using BlazorGrpcWebCodeFirst.Shared;

namespace BlazorGrpcWebCodeFirst.Server.Services;

public class MyService : IMyService
{
	public async Task<MyServiceResult> DoSomethingAsync(MyServiceRequest request, CancellationToken cancellationToken = default)
	{
		await Task.Delay(1);
		
		return new MyServiceResult()
		{
			Data = CultureInfo.GetCultures(CultureTypes.AllCultures).Select(ci => ci.DisplayName).ToArray()
		};
	}
}

