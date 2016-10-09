 //Random User Agent from file C#
 private static string RandomUa()
 {
     string[] lines;
     var list = new List<string>();
     var fileStream = new FileStream(Directory.GetCurrentDirectory() + "\\listua.txt", FileMode.Open, FileAccess.Read);
     using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
     {
         string line;
         while ((line = streamReader.ReadLine()) != null)
         {
             list.Add(line);
         }
     }
     lines = list.ToArray();
     return lines.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
 }
