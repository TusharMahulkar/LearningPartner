namespace eShopWebApplication.Models
{
    public class ApiResponse<T>
    {
        public ApiResponse()
        {
            Data = new List<T>();
        }
        public bool IsSucess { get; set; }
		public string Message { get; set; }
        public List<string> ErrorMessage { get; set; }
        public bool hasMoreData { get; set; }
		public int pageNumber { get; set; } = 1;

		public int pageSize { get; set; } = 10;

        public int totalRecords { get; set; }

		public int statusCode { get; set; }

		public List<T> Data { get; set; }
    }
}
