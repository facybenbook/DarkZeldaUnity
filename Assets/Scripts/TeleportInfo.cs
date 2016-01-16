public class TeleportInfo
{
    public string id;
    public string SceneName;
    public string facing;

    public TeleportInfo(string id, string scenename, string facing)
    {
        this.id = id;
        this.SceneName = scenename;
        this.facing = facing;
    }
}