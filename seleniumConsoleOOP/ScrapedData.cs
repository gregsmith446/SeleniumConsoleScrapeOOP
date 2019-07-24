﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace seleniumConsoleOOP
{
    class ScrapedData
    {
        private IList<IWebElement> _stockSymbols;
        private IList<IWebElement> _stockLastPrices;
        private IList<IWebElement> _stockChangePercents;
        private IList<IWebElement> _stockVolumes;
        private IList<IWebElement> _stockAvgVolumes;
        private IList<IWebElement> _stockMarketCaps;

        public IList<IWebElement> StockSymbols { get => _stockSymbols; set => _stockSymbols = value; }
        public IList<IWebElement> StockLastPrices { get => _stockLastPrices; set => _stockLastPrices = value; }
        public IList<IWebElement> StockChangePercents { get => _stockChangePercents; set => _stockChangePercents = value; }
        public IList<IWebElement> StockVolumes { get => _stockVolumes; set => _stockVolumes = value; }
        public IList<IWebElement> StockAvgVolumes { get => _stockAvgVolumes; set => _stockAvgVolumes = value; }
        public IList<IWebElement> StockMarketCaps { get => _stockMarketCaps; set => _stockMarketCaps = value; }

        public ScrapedData(IList<IWebElement> symbols, IList<IWebElement> lastPrices,
                    IList<IWebElement> changePercents,
                    IList<IWebElement> volumes, IList<IWebElement> avgVolumes,
                    IList<IWebElement> marketCaps)
        {
            this.StockSymbols = symbols;
            this.StockLastPrices = lastPrices;
            this.StockChangePercents = changePercents;
            this.StockVolumes = volumes;
            this.StockAvgVolumes = avgVolumes;
            this.StockMarketCaps = marketCaps;
        }
    }
}
