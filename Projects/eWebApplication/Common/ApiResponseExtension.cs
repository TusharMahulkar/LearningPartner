using eShopWebApplication.Models;


namespace eShopWebApplication.Common
{
    public static class ApiResponseExtension
    {
        public static ApiResponse<T> apiSuccessResponse<T>(this T data, string _message)
        {
            ApiResponse<T> apiResponse = new ApiResponse<T>();

            apiResponse.statusCode = 200;
            apiResponse.IsSucess = true;
            apiResponse.ErrorMessage = new List<string>();
            apiResponse.Message = _message;
            apiResponse.Data.Add(data);

            return apiResponse;
        }

        public static ApiResponse<T> apiErrorResponse<T>(this T data, string _message, string errorMesage)
        {
            ApiResponse<T> apiFailedResponse = new ApiResponse<T>();

            apiFailedResponse.IsSucess = false;
            apiFailedResponse.statusCode = 500;
            apiFailedResponse.ErrorMessage = new List<string>() { errorMesage };
            apiFailedResponse.Message = _message;
            
            return apiFailedResponse;
        }

    }
}
