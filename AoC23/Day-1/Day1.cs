using System.Collections.Generic;

internal static class Day1 {
  public static void First() {
    using StreamReader sr = new StreamReader("./Day-1/Data.txt");
    int sum = 0;
    while(!sr.EndOfStream) {
      string line = sr.ReadLine()!;
      int first = -1;
      int last = -1;
      for(int i = 0; i < line.Length; i++) {
        if(char.IsDigit(line[i])) {
          if(first == -1) {
            first = line[i] - '0';
            last = line[i] - '0';
          }
          else {
            last = line[i] - '0';
          }
        }
      }
      sum += first * 10 + last;
    }
    sr.Close();
    Console.WriteLine(sum);
  }

  public static void Second() {
    using StreamReader sr = new StreamReader("./Day-1/Data.txt");
    Dictionary<string, int> map = new() {
      {"one", 1},
      {"two", 2},
      {"three", 3},
      {"four", 4},
      {"five", 5},
      {"six", 6},
      {"seven", 7},
      {"eight", 8},
      {"nine", 9}
    };
    int sum = 0;

    while(!sr.EndOfStream) {
      string line = sr.ReadLine()!;
      int first = -1;
      int last = -1;
      int idxFirst = int.MaxValue, idxLast = int.MinValue;

      foreach(var item in map) {
        if(line.Contains(item.Key)) {
          if(first == -1) {
            first = item.Value;
            last = item.Value;
            idxFirst = line.IndexOf(item.Key);
            idxLast = line.LastIndexOf(item.Key) + item.Key.Length - 1;
          }
          if(idxFirst >= line.IndexOf(item.Key)) {
            first = item.Value;
            idxFirst = line.IndexOf(item.Key);
          }
          if(idxLast <= line.LastIndexOf(item.Key)) {
            last = item.Value;
            idxLast = line.LastIndexOf(item.Key) + item.Key.Length - 1;
          }
        }
        if(line.Contains((item.Value.ToString()))) {
          if(first == -1) {
            first = item.Value;
            last = item.Value;
            idxFirst = line.IndexOf(item.Value.ToString());
            idxLast = line.LastIndexOf(item.Value.ToString());
          }
          if(idxFirst >= line.IndexOf(item.Value.ToString())) {
            first = item.Value;
            idxFirst = line.IndexOf(item.Value.ToString());
          }
          if(idxLast <= line.LastIndexOf(item.Value.ToString())) {
            last = item.Value;
            idxLast = line.LastIndexOf(item.Value.ToString());
          }
        }
      };

      sum += first * 10 + last;
      //Console.WriteLine($"{line} - {first * 10 + last}");
    }

    Console.WriteLine(sum);
  }
}