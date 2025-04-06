using System.Net;

namespace BiddingManagementSystem.Application.Common
{
    public class BaseResponse<T>
    {
        public T? Data { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }

        public BaseResponse(HttpStatusCode httpStatusCode, string message, T? data)
        {
            HttpStatusCode = httpStatusCode;
            Message = message;
            Timestamp = DateTime.UtcNow;
            Data = data;
        }
        public BaseResponse(T? data, string message)
        {
            Message = message;
            Timestamp = DateTime.UtcNow;
        }
        public BaseResponse(HttpStatusCode httpStatusCode, string message)
        {
            HttpStatusCode = httpStatusCode;
            Message = message;
            Timestamp = DateTime.UtcNow;
        }

        // ✅ When a request is successfully processed and returns data.
        public static BaseResponse<T> SuccessResponse(T? data, string message = "Successfully Operation")
        {
            return new BaseResponse<T>(HttpStatusCode.OK, message, data);
        }

        //  ✅ When a new resource is successfully created (creating author, book, user).
        public static BaseResponse<T> CreatedResponse(T? data, string message = "Resource created successfully")
        {
            return new BaseResponse<T>(HttpStatusCode.Created, message, data);
        }
        public static BaseResponse<T> CreatedResponse(string message = "Resource created successfully")
        {
            return new BaseResponse<T>(HttpStatusCode.Created, message);
        }

        //  ✅ When the operation succeeds but doesn’t need to return data ( successful delete operation).
        public static BaseResponse<T> NoContentResponse(string message = "No Content Available!")
        {
            return new BaseResponse<T>(HttpStatusCode.NoContent, message, default);
        }


        // ❌ When the request is invalid (e.g., missing required fields, incorrect format).
        public static BaseResponse<T> ErrorResponse(string message = "Failed Operation!")
        {
            return new BaseResponse<T>(HttpStatusCode.BadRequest, message, default);
        }
        public static BaseResponse<T> ErrorResponse(T? data, string message = "Failed Operation!")
        {
            return new BaseResponse<T>(HttpStatusCode.BadRequest, message, data);
        }

        // ❌ When the requested resource doesn’t exist (searching for a non-existent book).
        public static BaseResponse<T> NotFoundResponse(string message = "Resource not found")
        {
            return new BaseResponse<T>(HttpStatusCode.NotFound, message);
        }


        // ❌ When an unexpected error occurs in the server.
        public static BaseResponse<T> InternalServerErrorResponse(string message = "An error occurred")
        {
            return new BaseResponse<T>(HttpStatusCode.InternalServerError, message);
        }

        // ❌ When input validation fails (e.g., missing fields, invalid email format).
        public static BaseResponse<T> ValidationErrorResponse(string message = "Validation failed")
        {
            return new BaseResponse<T>(HttpStatusCode.UnprocessableEntity, message);
        }

        // ❌ When a conflict occurs (e.g., trying to create a duplicate entry).
        public static BaseResponse<T> ConflictResponse(string message = "Conflict detected")
        {
            return new BaseResponse<T>(HttpStatusCode.Conflict, message);
        }

        public static BaseResponse<T> UnAuthorizeResponse(string message = "UnAuthorize detected")
        {
            return new BaseResponse<T>(HttpStatusCode.Unauthorized, message);
        }
    }

}
