using System.Text.Json;
using System.Text.Json.Serialization;

namespace Odev2.Views;

public partial class DovizKurlari : ContentPage
{
    public DovizKurlari()
    {
        InitializeComponent();
    }
    private static DovizKurlari instance;
    public static DovizKurlari Page
    {
        get
        {
            if (instance == null)
                instance = new DovizKurlari();
            return instance;
        }
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        await Load();
    }

    AltinDoviz kurlar;
    async Task Load()
    {
        string jsondata = await GetAltinDovizGuncelKurlar();

        kurlar = JsonSerializer.Deserialize<AltinDoviz>(jsondata);

        dovizliste.ItemsSource = new List<Doviz>()
        {
            new Doviz()
            {
                DName = "Dolar",
                FAlis = kurlar.USD.alis,
                FSatis = kurlar.USD.satis,
                Fark = kurlar.USD.degisim,
                Yon = GetImage(kurlar.USD.d_yon)

            },

            new Doviz()
            {
                DName = "EURO",
                FAlis = kurlar.EUR.alis,
                FSatis = kurlar.EUR.satis,
                Fark = kurlar.EUR.degisim,
                Yon = GetImage(kurlar.EUR.d_yon)

            },

            new Doviz()
            {
                DName = "Sterlin",
                FAlis = kurlar.GBP.alis,
                FSatis = kurlar.GBP.satis,
                Fark = kurlar.GBP.degisim,
                Yon = GetImage(kurlar.GBP.d_yon)

            },

            new Doviz()
            {
                DName = "---",
                FAlis = "",
                FSatis = "",
                Fark = "",
                Yon = "",

            },

            new Doviz()
            {
                DName = "Gram Altin",
                FAlis = kurlar.GA.alis,
                FSatis = kurlar.GA.satis,
                Fark = kurlar.GA.degisim,
                Yon = GetImage(kurlar.GA.d_yon)

            },

            new Doviz()
            {
                DName = "Ceyrek Altin",
                FAlis = kurlar.C.alis,
                FSatis = kurlar.C.satis,
                Fark = kurlar.C.degisim,
                Yon = GetImage(kurlar.C.d_yon)

            },

            new Doviz()
            {
                DName = "Gumus",
                FAlis = kurlar.GAG.alis,
                FSatis = kurlar.GAG.satis,
                Fark = kurlar.GAG.degisim,
                Yon = GetImage(kurlar.GAG.d_yon)

            },

            new Doviz()
            {
                DName = "---",
                FAlis = "",
                FSatis = "",
                Fark = "",
                Yon = "",

            },

            new Doviz()
            {
                DName = "BTC",
                FAlis = kurlar.BTC.alis,
                FSatis = kurlar.BTC.satis,
                Fark = kurlar.BTC.degisim,
                Yon = GetImage(kurlar.BTC.d_yon)

            },

            new Doviz()
            {
                DName = "ETH",
                FAlis = kurlar.ETH.alis,
                FSatis = kurlar.ETH.satis,
                Fark = kurlar.ETH.degisim,
                Yon = GetImage(kurlar.ETH.d_yon)

            },
        };
    }


    private string GetImage(string str)
    {
        if (str.Contains("up"))
            return "up.png";
        if (str.Contains("down"))
            return "    down.png";
        if (str.Contains("minus"))
            return "sil.png";

        return "";
    }

        
    async Task<string> GetAltinDovizGuncelKurlar()
    {
        String url = "https://api.genelpara.com/embed/altin.json";
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        String jsondata = await response.Content.ReadAsStringAsync();
        return jsondata;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Load();
    }
}

public class Doviz
{
    public String DName { get; set; }
    public String FAlis { get; set; }
    public String FSatis { get; set; }
    public String Fark { get; set; }
    public String Yon { get; set; }

}
public class AltinDoviz
{
    public USD USD { get; set; }
    public EUR EUR { get; set; }
    public GBP GBP { get; set; }
    public GA GA { get; set; }
    public C C { get; set; }
    public GAG GAG { get; set; }
    public BTC BTC { get; set; }
    public ETH ETH { get; set; }
    public XU100 XU100 { get; set; }
}
public class BTC
{
    public string satis { get; set; }
    public string alis { get; set; }
    public string degisim { get; set; }
    public string d_oran { get; set; }
    public string d_yon { get; set; }
}

public class C
{
    public string satis { get; set; }
    public string alis { get; set; }
    public string degisim { get; set; }
    public string d_oran { get; set; }
    public string d_yon { get; set; }
}

public class ETH
{
    public string satis { get; set; }
    public string alis { get; set; }
    public string degisim { get; set; }
    public string d_oran { get; set; }
    public string d_yon { get; set; }
}

public class EUR
{
    public string satis { get; set; }
    public string alis { get; set; }
    public string degisim { get; set; }
    public string d_oran { get; set; }
    public string d_yon { get; set; }
}

public class GA
{
    public string satis { get; set; }
    public string alis { get; set; }
    public string degisim { get; set; }
    public string d_oran { get; set; }
    public string d_yon { get; set; }
}

public class GAG
{
    public string satis { get; set; }
    public string alis { get; set; }
    public string degisim { get; set; }
    public string d_oran { get; set; }
    public string d_yon { get; set; }
}

public class GBP
{
    public string satis { get; set; }
    public string alis { get; set; }
    public string degisim { get; set; }
    public string d_oran { get; set; }
    public string d_yon { get; set; }
}



public class USD
{
    public string satis { get; set; }
    public string alis { get; set; }
    public string degisim { get; set; }
    public string d_oran { get; set; }
    public string d_yon { get; set; }
}

public class XU100
{
    public string satis { get; set; }
    public string alis { get; set; }
    public string degisim { get; set; }
}

