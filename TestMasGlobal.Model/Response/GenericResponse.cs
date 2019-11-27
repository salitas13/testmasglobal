namespace TestMasGlobal.Model.Response
{
    public class GenericResponse<T>
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
    }
}
