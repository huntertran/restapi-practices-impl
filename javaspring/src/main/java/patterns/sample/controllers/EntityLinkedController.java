package patterns.sample.controllers;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

import patterns.sample.utils.EntityLinking.LinkedResource;
import patterns.sample.utils.EntityLinking.ResourceVisitor;
import patterns.sample.utils.EntityLinking.ResourceVisitorImplementation;

@RestController
// double dispatch
public class EntityLinkedController {
    @GetMapping("/entitylinked")
    public String get() {
        LinkedResource[] resources = new LinkedResource[] { new SampleRelatedResourceController() };

        ResourceVisitor visitor = new ResourceVisitorImplementation();

        String result = "";

        for (LinkedResource resource : resources) {
            result += resource.accept(visitor);
        }

        return result;
    }
}