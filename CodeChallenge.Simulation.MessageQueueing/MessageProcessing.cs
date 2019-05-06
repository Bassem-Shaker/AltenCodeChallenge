using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.Simulation.MessageQueueing
{
    public class MessageProcessing
    {
        public void EnqueMessage(String message)
        {
            
            string senderUniqueId = "vehicleInsertMsgQ";

            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
            var connection = factory.CreateConnection();

            //-------------------------  Sending Data --------------------------------------------------------------------------------------
            #region Sending Data
            using (var channel = connection.CreateModel())
            {

                channel.QueueDeclare(queue: "vehicleInsertMsgQ", durable: false, exclusive: false, autoDelete: false, arguments: null);

                // create serialize object to send

                var body = Encoding.UTF8.GetBytes(message);

                IBasicProperties properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                properties.DeliveryMode = 2;
                properties.Headers = new Dictionary<string, object>();
                properties.Headers.Add("vehicleInsertMsgQ", senderUniqueId);//optional unique sender details in receiver side              

                channel.ConfirmSelect();

                channel.BasicPublish(exchange: "",
                                     routingKey: "vehicleInsertMsgQ",
                                     basicProperties: properties,
                                     body: body);

                channel.WaitForConfirmsOrDie();

                channel.BasicAcks += (sender, eventArgs) =>
                {
                    Console.WriteLine("Sent RabbitMQ");
                    //implement ack handle
                };
                channel.ConfirmSelect();

            }
            #endregion

            //-------------------------  Receiving feedback ---------------------------------------------------------------------------------
            #region Feedback Received part
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "vehicleInsertMsgQ_feedback",
                                   durable: false,
                                   exclusive: false,
                                   autoDelete: false,
                                   arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    IDictionary<string, object> headers = ea.BasicProperties.Headers; // get headers from Received msg

                    foreach (KeyValuePair<string, object> header in headers)
                    {
                        if (senderUniqueId == Encoding.UTF8.GetString((byte[])header.Value))// Get feedback message only for me
                        {
                            //var body = ea.Body;
                            //var message = Encoding.UTF8.GetString(body);
                            //UserSaveFeedback feedback = JsonConvert.DeserializeObject<UserSaveFeedback>(message);
                            Console.WriteLine("[x] Feedback received ... ");
                        }
                    }
                };

                channel.BasicConsume(queue: "vehicleInsertMsgQ_feedback",
                                     autoAck: true,
                                     consumer: consumer);

            }
            #endregion
        }

    }
}
