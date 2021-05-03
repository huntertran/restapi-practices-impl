package patterns.sample.controllers;

import java.time.LocalDate;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import patterns.sample.utils.contentnegotiation.formats.BaseObject;
import patterns.sample.utils.contentnegotiation.formats.ObjectFactory;
import patterns.sample.utils.contentnegotiation.models.Weather;

@RestController
@RequestMapping("/contentnegotiation")
public class ContentNegotiationController {
    @GetMapping("/resource")
    public String getResource(@RequestHeader("accept") String accept) {
        Weather[] weathers = new Weather[2];

        LocalDate today = LocalDate.now();

        weathers[0] = new Weather(today, 15.6);
        weathers[1] = new Weather(today.plusDays(1), 17);

        BaseObject serializer = ObjectFactory.getObject(accept);
        return serializer.serialize(weathers);
    }
}