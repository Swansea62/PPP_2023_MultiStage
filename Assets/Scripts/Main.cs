using UnityEngine;

public class Main : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private static void OnAppStart()
    {
        var user2 = new User("Peter", "Capaldi", 61);
        DatabaseHandler.PostUser(user2, "12", () =>
        {
            DatabaseHandler.GetUser("12", user =>
            {
                Debug.Log($"{user.name} {user.surname} {user.age}");
            });
        });
    }
}
