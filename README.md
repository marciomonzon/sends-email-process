# Email Notification Service
<p>This project is a Email Notification Service made for stuying purpose. This should not be use in a Prod Env.</p>

## Stack
* .NET 8;
* ASP.NET API Core (SendsEmail);
* .NET Worker Service (SendEmailWorker);
* RabbitMq Client (Both projects);
* RabbitMq Server;

## How it Works?
* The API, SendsEmail, sends the e-mail settings and body to the RabbitMq Server (Queue);
* The Worker Service, SendEmailWorker, get this message from the queue and send an email using smtp server.

<p>Please, take a look in the diagram below to understand its flow.</p>

<br>

![image](https://github.com/user-attachments/assets/088ddf8e-f5cc-4645-8856-cb572e869e74)

<br>
