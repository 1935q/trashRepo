
  Gecko.Xpcom.Initialize("Firefox");
  Gecko.GeckoPreferences.Default["extensions.blocklist.enabled"] = false;
  Gecko.GeckoPreferences.Default["general.useragent.override"] = "Mozilla/5.0 (iPhone; CPU iPhone OS 6_0 like Mac OS X) AppleWebKit/536.26 (KHTML, like Gecko) Version/6.0 Mobile/10A5376e Safari/8536.25";
  if (args.Length > 1)
  {
      Gecko.GeckoPreferences.User["network.proxy.type"] = 1;
      Gecko.GeckoPreferences.User["network.proxy.socks"] = "127.0.0.1";
      Gecko.GeckoPreferences.User["network.proxy.socks_port"] = Int32.Parse(args[1]);
      Gecko.GeckoPreferences.User["network.proxy.socks_version"] = 5;
  }

//Delete cookie in gecko c#
  nsICookieManager CookieMan;
  CookieMan = Xpcom.GetService<nsICookieManager>("@mozilla.org/cookiemanager;1");
  CookieMan = Xpcom.QueryInterface<nsICookieManager>(CookieMan);
  CookieMan.RemoveAll();
//Deleet all history in gecko C#
  nsIBrowserHistory historyMan = Xpcom.GetService<nsIBrowserHistory>(Gecko.Contracts.NavHistoryService);
  historyMan = Xpcom.QueryInterface<nsIBrowserHistory>(historyMan);
  historyMan.RemoveAllPages();

  string referrer;
  if (args.Length > 2)
      referrer = WebUtility.UrlDecode( args[2] );
  else
      referrer = "https://www.facebook.com/";
   geckoWebBrowser = new GeckoWebBrowser { Dock = DockStyle.Fill };
  //Form f = new Form();
  Form f = new Form();
  f.Controls.Add(geckoWebBrowser);
  f.Width = 1000;
  f.Height = 700;
  //geckoWebBrowser.Document.Cookie = "";
  string url;
  if (args.Length > 0)
  {
      url = args[0];
  }
  else
  {
      url = "ylx-4.com/fullpage.php?section=General&pub=751191&ga=g";
  }

//Set Referer in gecko C#
  //GeckoMIMEInputStream strea = new GeckoMIMEInputStream();
  Gecko.IO.MimeInputStream strea = MimeInputStream.Create();
  if ( referrer != "" )
      strea.AddHeader("Referer", referrer);


  geckoWebBrowser.Navigate(url, Gecko.GeckoLoadFlags.BypassHistory,  "", null, strea);

  geckoWebBrowser.DocumentCompleted += GeckoWebBrowser3_DocumentCompleted;
  geckoWebBrowser.Navigated += GeckoWebBrowser_Navigated;
  geckoWebBrowser.Navigating += GeckoWebBrowser_Navigating;
 //geckoWebBrowser.NavigateFinishedNotifier = true;

  Console.WriteLine("Creaded: " + geckoWebBrowser.Created);
  //f.Visible = true;
  f.Show();
  Console.WriteLine("created 2 " + geckoWebBrowser.IsBusy);
