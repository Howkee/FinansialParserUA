using MoneyParserUA.Core;
using MoneyParserUA.Core.Model;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MoneyParserUA
{
    public partial class MainWindow : Window
    {
        ParserWorker<string[]> bankPriceParser;
        ParserWorker<string[]> NBYPriceParser;
        ParserWorker<string[]> blackMarketParser;

        ParserSettings parserSettings = new ParserSettings();


        public MainWindow()
        {
            InitializeComponent();

            bankPriceParser = new ParserWorker<string[]>(new BankPriceParser(), parserSettings);
            NBYPriceParser = new ParserWorker<string[]>(new NBYParser(), parserSettings);
            blackMarketParser = new ParserWorker<string[]>(new BlackMarketParser(), parserSettings);

            bankPriceParser.OnCompleted += BankPriseWrite;
            bankPriceParser.Work();

            NBYPriceParser.OnCompleted += NBYPriceWrite;
            NBYPriceParser.Work();

            blackMarketParser.OnCompleted += BlackMarketPriceWrite;
            blackMarketParser.Work();

        }

        private void BankPriseWrite(object arg1, string[] arg2)
        {
            for (int i = 0; i < BuyingSelling.Children.Count; i++)
            {
                if (BuyingSelling.Children[i] is TextBlock)
                {
                    string[] value = arg2[i].Replace('\n', ' ').Trim().Split(' ');
                    (BuyingSelling.Children[i] as TextBlock).Text = value[0] + " / " + value[value.Length - 1];
                }
            }
        }

        private void BlackMarketPriceWrite(object arg1, string[] arg2)
        {
            for (int i = 0; i < BlackMarket.Children.Count; i++)
            {
                if (BlackMarket.Children[i] is TextBlock)
                {
                    string[] value = arg2[i].Replace('\n', ' ').Trim().Split(' ');
                    (BlackMarket.Children[i] as TextBlock).Text = value[0] + " / " + value[value.Length - 1];
                }
            }
        }

        private void NBYPriceWrite(object arg1, string[] arg2)
        {
            for (int i = 0; i < NBY.Children.Count; i++)
            {
                if (NBY.Children[i] is TextBlock)
                {
                    (NBY.Children[i] as TextBlock).Text = arg2[i].Substring(0,9).Trim();
                }
            }
        }
    }
}
