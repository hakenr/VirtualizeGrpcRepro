using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BlazorGrpcWebCodeFirst.Shared;

[ServiceContract]
public interface IMyService
{
	[OperationContract]
	Task<MyServiceResult> DoSomethingAsync(MyServiceRequest request, CancellationToken cancellationToken = default);
}

