using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;

namespace Securities.Lib;

public class SecuritiesService : ISecuritiesService
{
    private List<Security> _securities = new();

    public Option<IEnumerable<Security>> GetSecurity(string ticker)
    {
        _securities = new List<Security>
        {
            new Security
            {
                Ticker = "AAPL",
                Date = new DateTime(2021, 1, 1),
                Open = 132.69m,
                High = 133.61m,
                Low = 126.76m,
                Close = 129.41m,
                Volume = 105158245
            },
            new Security
            {
                Ticker = "MSFT",
                Date = new DateTime(2021, 1, 2),
                Open = 133.52m,
                High = 135.99m,
                Low = 133.52m,
                Close = 135.35m,
                Volume = 100620900
            },
            new Security
            {
                Ticker = "TSLA",
                Date = new DateTime(2021, 1, 3),
                Open = 133.99m,
                High = 134.67m,
                Low = 133.52m,
                Close = 134.08m,
                Volume = 90102500
            }
        };

       return _securities.Any()
            ? Option<IEnumerable<Security>>.Some(_securities.Where(s => s.Ticker == ticker))
            : Option<IEnumerable<Security>>.None;
    }

    public Option<IEnumerable<Security>> GetSecurities()
    {
        _securities = new List<Security>
        {
            new Security
            {
                Ticker = "AAPL",
                Date = new DateTime(2021, 1, 1),
                Open = 132.69m,
                High = 133.61m,
                Low = 126.76m,
                Close = 129.41m,
                Volume = 105158245
            },
            new Security
            {
                Ticker = "MSFT",
                Date = new DateTime(2021, 1, 2),
                Open = 133.52m,
                High = 135.99m,
                Low = 133.52m,
                Close = 135.35m,
                Volume = 100620900
            },
            new Security
            {
                Ticker = "TSLA",
                Date = new DateTime(2021, 1, 3),
                Open = 133.99m,
                High = 134.67m,
                Low = 133.52m,
                Close = 134.08m,
                Volume = 90102500
            }
        };

        return _securities.Any()
            ? Option<IEnumerable<Security>>.Some(_securities)
            : Option<IEnumerable<Security>>.None;
    }
}