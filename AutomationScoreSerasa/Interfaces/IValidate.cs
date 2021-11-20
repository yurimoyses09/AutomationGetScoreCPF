namespace AutomationScoreSerasa.Interfaces
{
    public interface IValidate
    {
        bool ValiadePassword(string password);
        bool ValidateCPF(string CPF);
        bool ValidadeLogin(string msg);
    }
}
