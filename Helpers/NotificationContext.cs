using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;


public interface IMobileMessagingClient
{
    FirebaseMessaging getMessaging();
}
public class MobileMessagingClient : IMobileMessagingClient
{
    public FirebaseMessaging messaging;

    public MobileMessagingClient()
    {
        var app = FirebaseApp.Create(new AppOptions() { Credential = GoogleCredential.FromFile("firebase_config.json").CreateScoped("https://www.googleapis.com/auth/firebase.messaging")});           
       messaging = FirebaseMessaging.GetMessaging(app);
    }
    public FirebaseMessaging getMessaging(){
        return messaging;
    }
}