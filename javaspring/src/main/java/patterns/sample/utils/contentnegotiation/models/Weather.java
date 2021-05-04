package patterns.sample.utils.contentnegotiation.models;

import java.time.LocalDate;

public class Weather {
    private LocalDate dateTime;
    private double temperature;

    public Weather(LocalDate dateTime, double temperature) {
        this.dateTime = dateTime;
        this.temperature = temperature;
    }

    public double getTemperature() {
        return temperature;
    }

    public void setTemperature(double temperature) {
        this.temperature = temperature;
    }

    public LocalDate getDateTime() {
        return dateTime;
    }

    public void setDateTime(LocalDate dateTime) {
        this.dateTime = dateTime;
    }
}
