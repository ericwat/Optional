namespace Securities.Lib;

public interface ISecuritiesService
{
    Option<IEnumerable<Security>> GetSecurity(string ticker);
    Option<IEnumerable<Security>> GetSecurities();
}