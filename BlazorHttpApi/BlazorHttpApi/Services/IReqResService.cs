using BlazorHttpApi.Models;

namespace BlazorHttpApi.Services;

public interface IReqResService
{
    Task<ReqResResponse> GetResponse();
    void CancelRequest();
    Task<ReqResCreateResponse> PostNewUser(ReqResRequest request);
}
