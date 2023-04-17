# Siły Policyjne Wielkiej Brytanii

Aplikacja przedstawia informacje na temat różnych formacji policji Wielkiej Brytanii. Dane dotyczące tych formacji są pobierane z restful API [Police API](https://data.police.uk/docs/) i zawierają informacje takie jak:
 - Nazwa jednoski
 - Strona internetowa jednostki
 - Numer telefonu
 - Opis jeśli takowy istnieje
 
 <br>

<div style="display: inline-block;" align="center">
  <h2>Zrzuty ekranu</h2>
  <table>
      <tr>
          <th colspan="3">Widok danych w różnych miejscach listy przed dodaniem pola wyszukiwania</th>
      </tr>
      <tr>
          <th><img src="https://github.com/xRalph18/DniOtwarteApp_xaml/blob/main/screens/DniOtwarte1.jpg" alt="AppScreen1" style="height: 500px;"/></th>
          <th><img src="https://github.com/xRalph18/DniOtwarteApp_xaml/blob/main/screens/DniOtwarte2.jpg" alt="AppScreen2" style="height: 500px;"/></th>
          <th><img src="https://github.com/xRalph18/DniOtwarteApp_xaml/blob/main/screens/DniOtwarte3.jpg" alt="AppScreen3" style="height: 500px;"/></th>
      </tr>
  </table>
  <h6><i>Znaczniki html są przesyłane jako wynik z API</i></h6>
</div>

<br>

<div style="display: inline-block;" align="center">
  <h2>Widok aplikacji z wprowadzonym polem wyszukiwania</h2>
  <table>
      <tr>
          <th><img src="https://github.com/xRalph18/DniOtwarteApp_xaml/blob/main/screens/DniOtwarte4.jpg" alt="AppScreen4" style="height: 500px;"/></th>
          <th><img src="https://github.com/xRalph18/DniOtwarteApp_xaml/blob/main/screens/DniOtwarte5.jpg" alt="AppScreen5" style="height: 500px;"/></th>
          <th><img src="https://github.com/xRalph18/DniOtwarteApp_xaml/blob/main/screens/DniOtwarte6.jpg" alt="AppScreen6" style="height: 500px;"/></th>
      </tr>
  </table>
  <h6><i>Znaczniki html są przesyłane jako wynik z API</i></h6>
</div>

<br>

# Pobieranie danych z API
### Lista Sił
```cs
public static List<ForcesModel> GetForces()
    {
    HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://data.police.uk/api/forces"));

    WebReq.Method = "GET";

    HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

    Console.WriteLine(WebResp.StatusCode);
    Console.WriteLine(WebResp.Server);

    string jsonString;
    using(Stream stream = WebResp.GetResponseStream())
    {
        StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
        jsonString = reader.ReadToEnd();
    }

    List<ForcesModel> forces = JsonConvert.DeserializeObject<List<ForcesModel>>(jsonString);

    return forces;
}
```

### Pobieranie Detali

```cs
public static ForceDetailModel GetForceDetail(string forceId)
{
    HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format($"https://data.police.uk/api/forces/{forceId}"));

    WebReq.Method = "GET";

    HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

    Console.WriteLine(WebResp.StatusCode);
    Console.WriteLine(WebResp.Server);

    string jsonString;
    using (Stream stream = WebResp.GetResponseStream())
    {
        StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
        jsonString = reader.ReadToEnd();
    }

    ForceDetailModel forceDetail = JsonConvert.DeserializeObject<ForceDetailModel>(jsonString);

    return forceDetail;
}
```

<br>

### Kod odpowiadający za wyszukiwanie
```cs
private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
{
  listView.ItemsSource = ForcesList.Where(s => s.name.ToLower().Replace(" ", "").Contains(e.NewTextValue.ToLower().Replace(" ", "")));
}
```

### Przykładowe dane zwracane przez API
```json
{
    "description":null,
    "url":"http:\/\/www.leics.police.uk\/",
    "engagement_methods":
    [
        { "url":"http:\/\/www.facebook.com\/leicspolice", "type":"facebook", "description":null, "title":"facebook" },
        { "url":"http:\/\/www.twitter.com\/leicspolice", "type":"twitter", "description":null, "title":"twitter" },
        { "url":"http:\/\/www.youtube.com\/leicspolice", "type":"youtube", "description":null, "title":"youtube" },
        { "url":"https:\/\/www.leics.police.uk\/news\/leicestershire\/news\/GetNewsRss\/", "type":"rss", "description":null, "title":"rss" },
        { "url":"", "type":"telephone", "description":null, "title":"telephone" }
    ],
    "telephone":"101",
    "id":"leicestershire",
    "name":"Leicestershire Police"
}
```

Autor: Rafał Machnik
  
Discord: Ralph18#1525
