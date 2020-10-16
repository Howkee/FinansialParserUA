using MoneyParserUA.Core;
using MoneyParserUA.Core.Model;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MoneyParserUA
{
    public partial class MainWindow : Window
    {
        ParserSettings parserSettings = new ParserSettings();

        public MainWindow()
        {
            InitializeComponent();

            ParserWorker<string[]> bankPriceParser = new ParserWorker<string[]>
                                (new BankPriceParser(), parserSettings);

            ParserWorker<string[]> NBYPriceParser = new ParserWorker<string[]>
                                (new NBYParser(), parserSettings);

            ParserWorker<string[]> blackMarketParser = new ParserWorker<string[]>
                                (new BlackMarketParser(), parserSettings);

            bankPriceParser.OnCompleted += BankPriseWrite;
            bankPriceParser.Work();

            NBYPriceParser.OnCompleted += NBYPriceWrite;
            NBYPriceParser.Work();

            blackMarketParser.OnCompleted += BlackMarketPriceWrite;
            blackMarketParser.Work();

        }

        private void BankPriseWrite(object arg1, string[] arg2)
        {
            TextRewrite(BuyingSelling, arg2);
        }

        private void BlackMarketPriceWrite(object arg1, string[] arg2)
        {
            TextRewrite(BlackMarket, arg2);
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
            
        private void TextRewrite(StackPanel stackPanel, string[] values)
        {
            for (int i = 0; i < stackPanel.Children.Count; i++)
            {
                if (stackPanel.Children[i] is TextBlock)
                {
                    string[] value = values[i].Replace('\n', ' ').Trim().Split(' ');
                    (stackPanel.Children[i] as TextBlock).Text = value[0] + " / " + value[value.Length - 1];
                }
            }
        }
    }
}
