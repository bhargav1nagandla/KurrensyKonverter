using System.Text.Json;
using System;
using System.Diagnostics;
using System.Text.Json.Serialization;
using CurrencyConverter.Models;
using System.Net.Http.Json;

namespace CurrencyConverter;

public partial class MainPage : ContentPage
{

    HttpClient _client;
    JsonSerializerOptions _serializerOptions;

    public MainPage()
    {
        InitializeComponent();
        _client = new HttpClient();
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

    }

    public void Convert(object sender, EventArgs e)
    {
        string amount = this.Amount.Text.ToString();
        string scountry = this.c1.Text.ToString().ToUpper();
        string dcountry = this.c2.Text.ToString().ToUpper();
        this.Result.Text = "You Clicked " + amount + " " + scountry + " " + dcountry;
        string url = "https://api.frankfurter.app/latest?amount=" + amount + "&from=" + scountry + "&to=" + dcountry;
        this.RefreshDataAsync(url,amount,scountry,dcountry);

    }
    public async void RefreshDataAsync(string url,string amount,string scountry, string dcountry)
    {
        
        List<Currency> Items = new List<Currency>(); 
        Uri uri = new Uri(string.Format(url, string.Empty));
        try
                       {                                                                                                                                                             
            HttpResponseMessage response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                String x = content.Substring(content.LastIndexOf(":")+1);

                x = x.Replace("}", "");
                
              //this.Result.Text = x;
                this.Result1.Text = amount + " " + scountry + " = " + x + " " + dcountry;

              
                     
              // Items = JsonSerializer.Deserialize<List<Currency>>(content, _serializerOptions);
               //this.Result.Text = "Hello"+Items.ToString();
                //Items = JsonSerializer.Deserialize<List<TodoItem>>(content, _serializerOptions);
              /*  foreach (Currency currency in Items)
                    {
                    this.Result.Text = "Hello"+currency.amount;
                    }
              */
              
                
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            this.Result.Text = ex.Message;
            
        }


    }

}

