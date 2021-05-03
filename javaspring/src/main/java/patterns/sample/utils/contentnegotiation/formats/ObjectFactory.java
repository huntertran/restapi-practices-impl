package patterns.sample.utils.contentnegotiation.formats;

public class ObjectFactory {
    public static BaseObject getObject(String type) {
        switch (type) {
            case "application/xml": {
                return new XmlObject();
            }
            case "application/json":
            default: {
                return new JsonObject();
            }
        }
    }
}
