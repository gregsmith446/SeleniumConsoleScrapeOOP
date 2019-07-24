﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace seleniumConsoleOOP
{
    class Stock
    {
        private string _symbol;
        private double _lastPrice;
        private double _changePercent;
        private string _volume;
        private string _avgVol;
        private string _marketCap;

        public string Symbol { get => _symbol; set => _symbol = value; }
        public double LastPrice { get => _lastPrice; set => _lastPrice = value; }
        public double ChangePercent { get => _changePercent; set => _changePercent = value; }
        public string Volume { get => _volume; set => _volume = value; }
        public string AvgVol { get => _avgVol; set => _avgVol = value; }
        public string MarketCap { get => _marketCap; set => _marketCap = value; }

        public Stock()
        {
        }

        public Stock(string symbol, double lastPrice,
                    double changePercent,
                    string vol, string volAvg, string marketCap)
        {
            this.Symbol = symbol;
            this.LastPrice = lastPrice;
            this.ChangePercent = changePercent;
            this.Volume = vol;
            this.AvgVol = volAvg;
            this.MarketCap = marketCap;
        }
    }
}

