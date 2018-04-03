namespace Paint101.Api
{
    public interface IParameterCollection
    {
        void RegisterParameter(ParameterTypes type, string key, object defaultValue);

        void RegisterParameter(ParameterTypes type, string key, object defaultValue, string displayName);

        object GetParameter(string key);

        T GetParameter<T>(string key);
    }
}
