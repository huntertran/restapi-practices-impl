package patterns.sample.utils.contentnegotiation.formats;

// import java.beans.XMLEncoder;
// import java.io.StringWriter;

// import javax.xml.bind.JAXBContext;
// import javax.xml.bind.JAXBException;
// import javax.xml.bind.Marshaller;

import com.thoughtworks.xstream.XStream;

public class XmlObject extends BaseObject {

    @Override
    public String serialize(Object object) {
        // JAXBContext jaxbContext;
        // StringWriter writer = new StringWriter();

        // try {
        // jaxbContext = JAXBContext.newInstance(Object.class);

        // Marshaller jaxbMarshaller = jaxbContext.createMarshaller();

        // // output pretty printed
        // jaxbMarshaller.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, true);

        // jaxbMarshaller.marshal(object, writer);
        // } catch (JAXBException e) {
        // e.printStackTrace();
        // }

        XStream xStream = new XStream();
        return xStream.toXML(object);
    }

}
