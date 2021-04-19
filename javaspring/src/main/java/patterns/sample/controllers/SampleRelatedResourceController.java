package patterns.sample.controllers;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

import patterns.sample.utils.EntityLinking.LinkedResource;
import patterns.sample.utils.EntityLinking.ResourceVisitor;

@RestController
public class SampleRelatedResourceController implements LinkedResource {
    @GetMapping("/samplerelatedresource/resource_a")
    public String getA() {
        return "ok";
    }

    @GetMapping("/samplerelatedresource/resource_b")
    public String getB() {
        return "ok";
    }

    @GetMapping("/samplerelatedresource/resource_c")
    public String getC() {
        return "ok";
    }

    @Override
    public String accept(ResourceVisitor visitor) {
        return visitor.visit(this);
    }
}
