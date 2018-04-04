namespace Shape.Api
{
    public interface IParameters
    {
        void AddParameter(string key, ParamaterTypes type, object defaultValue, string displayName);

        object GetParameter(string key);
    }
}
