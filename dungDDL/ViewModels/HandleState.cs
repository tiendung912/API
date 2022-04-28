namespace dungDDL.ViewModels
{
    public class HandleState
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public HandleState(bool isSuccess, string mess)
        {
            this.IsSuccess=isSuccess;
            this.Message=mess;
        }
    }
}