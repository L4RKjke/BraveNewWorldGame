[System.Serializable]
public class ItemData
{
    public int[] Level;
    public string[] Type;
    public int[] SearchID;

    public ItemData(PlayerItemStorage playerItemStorage)
    {
        Level = new int[playerItemStorage.CountItems - 1];
        Type = new string[playerItemStorage.CountItems - 1];
        SearchID = new int[playerItemStorage.CountItems - 1];

        for (int i = 0; i < playerItemStorage.CountItems - 1; i++)
        {
            if (playerItemStorage.GetItem(i + 1) != null)
            {
                Level[i] = playerItemStorage.GetItem(i + 1).Level;
                Type[i] = playerItemStorage.GetItem(i + 1).Type.ToString();
                SearchID[i] = playerItemStorage.GetItem(i + 1).SearchID;
            }
            else
            {
                SearchID[i] = -1;
            }
        }
    }
}
