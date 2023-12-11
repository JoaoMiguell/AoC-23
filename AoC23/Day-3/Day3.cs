struct Num {
  public int num;
  public int x;
  public int y;
}

internal static class Day3 {
  static StreamReader sr = new StreamReader("./Day-3/Data.txt");
  static List<string> list = new();

  static Day3() {
    while(!sr.EndOfStream)
      list.Add(sr.ReadLine() + '.');
  }

  public static void First() {
    int sum = 0;
    for(int col = 0; col < list.Count; col++) {
      string temp = "";
      for(int rowItem = 0; rowItem < list[col].Length; rowItem++) {
        if(rowItem < 140 && char.IsDigit(list[col][rowItem])) {
          temp += list[col][rowItem];
        }
        else {
          if(temp.Length >= 1) {
            bool found = false;
            for(int y = col <= 0 ? 0 : col - 1; y <= col + 1; y++) {
              for(int x = rowItem - 1 - temp.Length <= 0 ? 0 : rowItem - 1 - temp.Length; x <= rowItem; x++) {

                if(found)
                  break;
                if(y == list.Count) 
                  continue;
                if(list[y][x == 140 ? 139 : x] != '.' && !char.IsDigit(list[y][x == 140 ? 139 : x])) {
                  sum += Convert.ToInt32(temp);
                  found = true;
                }
              }
              if(found)
                break;
            }

            temp = "";
          }
        }
      }
    }

    Console.WriteLine(sum);
  }

  public static void Second() {
    List<Num> nums = new();
    int sum = 0;
    for(int col = 0; col < list.Count; col++) {
      string temp = "";
      for(int rowItem = 0; rowItem < list[col].Length; rowItem++) {
        if(rowItem < 140 && char.IsDigit(list[col][rowItem]))
          temp += list[col][rowItem];
        else {
          if(temp.Length >= 1) {
            for(int y = col <= 0 ? 0 : col - 1; y <= col + 1; y++) {
              for(int x = rowItem - 1 - temp.Length <= 0 ? 0 : rowItem - 1 - temp.Length; x <= rowItem; x++) {
                if(y == list.Count)
                  continue;
                if(list[y][x] == '*')
                  nums.Add(new Num() { num = Convert.ToInt32(temp), x = x, y = y });
              }
            }
            temp = "";
          }
        }
      }
    }


    for(int i = 0; i < nums.Count - 1; i++) {
      Num a = nums[i];
      for(int j = 0; j < nums.Count; j++) {
        Num b = nums[j];
        if(a.y == b.y && a.x == b.x && i != j) {
          sum += (a.num * b.num);
          nums.Remove(a);
          nums.Remove(b);
          i -= 2;
        }
      }
    }

    Console.WriteLine(sum);
  }
}