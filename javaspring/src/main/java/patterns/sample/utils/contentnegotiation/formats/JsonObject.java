package patterns.sample.utils.contentnegotiation.formats;

import com.google.gson.Gson;

public class JsonObject extends BaseObject {

    @Override
    public String serialize(Object object) {
        Gson gson = new Gson();
        return gson.toJson(object);
    }
    
}
