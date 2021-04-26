package patterns.sample.controllers;

import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import patterns.sample.services.TimeOutTask;

@RestController
@RequestMapping("/forceabort")
public class ForceAbortController {

    Future<String> future;

    @GetMapping("/")
    public String get() {
        ExecutorService executor = Executors.newSingleThreadExecutor();
        future = executor.submit(new TimeOutTask(10000));

        try {
            future.get();
        } catch (Exception e) {
            System.out.println("Task throw exception: " + e.toString());
        }

        return new String("ok");
    }

    @PostMapping("/")
    public String post() {

        if (future != null) {
            boolean result = future.cancel(true);
            if (result) {
                return new String("task cancelled");
            } else {
                return new String("task is still running");
            }
        } else {
            return "Task is not started";
        }
    }
}