using System.Runtime.Serialization;

namespace BlazorGrpcWebCodeFirst.Shared;

[DataContract]
public class MyServiceResult
{
	[DataMember(Order = 1)]
	public string[] Data { get; set; }
}
