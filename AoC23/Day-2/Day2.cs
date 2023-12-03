internal static class Day2 {
  public static void First() {
    using StreamReader sr = new StreamReader("./Day-2/Data.txt");
    int limitRed = 12, limitGreen = 13, limitBlue = 14;

    int sumGames = 0;

    while(!sr.EndOfStream) {
      string[] gameAndData = sr.ReadLine()!.Split(':');
      string[] rounds = gameAndData[1].Trim().Split(";");

      bool isValid = true;
      foreach(string round in rounds) {
        if(round.Contains(',')) {
          string[] values = round.Trim().Split(',');
          foreach(string value in values) {
            string[] numAndColor = value.Trim().Split(' ');
            switch(numAndColor[1]) {
              case "red":
              if(int.Parse(numAndColor[0]) > limitRed)
                isValid = false;
              break;
              case "green":
              if(int.Parse(numAndColor[0]) > limitGreen)
                isValid = false;
              break;
              case "blue":
              if(int.Parse(numAndColor[0]) > limitBlue)
                isValid = false;
              break;
            }
          }
        }
        else {
          string[] numAndColor = round.Trim().Split(' ');
          switch(numAndColor[1]) {
            case "red":
            if(int.Parse(numAndColor[0]) > limitRed)
              isValid = false;
            break;
            case "green":
            if(int.Parse(numAndColor[0]) > limitGreen)
              isValid = false;
            break;
            case "blue":
            if(int.Parse(numAndColor[0]) > limitBlue)
              isValid = false;
            break;
          }
        }
      }
      if(isValid)
        sumGames += Convert.ToInt32(gameAndData[0].Split(' ')[1]);

    }
    Console.WriteLine(sumGames);
  }

  public static void Second() {
    using StreamReader sr = new StreamReader("./Day-2/Data.txt");

    int sum = 0;

    while(!sr.EndOfStream) {
      int minRed = 0, minGreen = 0, minBlue = 0;
      string[] gameAndData = sr.ReadLine()!.Split(':');
      string[] rounds = gameAndData[1].Trim().Split(";");

      foreach(string round in rounds) {
        if(round.Contains(',')) {
          string[] values = round.Trim().Split(',');
          foreach(string value in values) {
            string[] numAndColor = value.Trim().Split(' ');
            switch(numAndColor[1]) {
              case "red":
              if(Convert.ToInt32(numAndColor[0]) > minRed)
                minRed = Convert.ToInt32(numAndColor[0]);
              break;
              case "green":
              if(Convert.ToInt32(numAndColor[0]) > minGreen)
                minGreen = Convert.ToInt32(numAndColor[0]);
              break;
              case "blue":
              if(Convert.ToInt32(numAndColor[0]) > minBlue)
                minBlue = Convert.ToInt32(numAndColor[0]);
              break;
            }
          }
        }
        else {
          string[] numAndColor = round.Trim().Split(' ');
          switch(numAndColor[1]) {
            case "red":
            if(Convert.ToInt32(numAndColor[0]) > minRed)
              minRed = Convert.ToInt32(numAndColor[0]);
            break;
            case "green":
            if(Convert.ToInt32(numAndColor[0]) > minGreen)
              minGreen = Convert.ToInt32(numAndColor[0]);
            break;
            case "blue":
            if(Convert.ToInt32(numAndColor[0]) > minBlue)
              minBlue = Convert.ToInt32(numAndColor[0]);
            break;
          }
        }
      }
      sum += (minRed * minGreen * minBlue);
    }

    Console.WriteLine(sum);
  }
}