import clsVue from 'vue';
import signalR, {HubConnectionBuilder, LogLevel} from '@aspnet/signalr';
import {EventBus} from '@/global/EventBus';

// https://www.dotnetcurry.com/aspnet-core/1480/aspnet-core-vuejs-signalr-app
// https://www.mistergoodcat.com/post/vuejs-plugins-with-typescript

export default function CoffeeHubPlugin(Vue: typeof clsVue, options?: any): void {

    // Connection to the SignalR CoffeeHub will be saved within the Vue class.
    Vue.prototype.$coffeeHubConnection = new HubConnectionBuilder()
        .withUrl('http://localhost:4746/coffeehub') // default usage: WebSockets.
        //.withUrl('http://localhost:4746/coffeehub', signalR.HttpTransportType.ServerSentEvents); // Use server sent events
        //.withUrl('http://localhost:4746/coffeehub', signalR.HttpTransportType.LongPolling); // Use long polling
        .configureLogging(LogLevel.Information)
        .build();

    Vue.prototype.$coffeeHubConnection.on('ReceiveOrderUpdate', (update: string) => {
        EventBus.$emit('order-status-changed', update)
    });

    Vue.prototype.$coffeeHubConnection.on('NewOrder', (order: string) => {
        EventBus.$emit('order-status-changed', 'Someone ordered a(n) ' + order + '.');
    });

    Vue.prototype.$coffeeHubConnection.on('Finished', () => {
        EventBus.$emit('order-status-changed', `Thank you for ordering.`);
    });

    Vue.prototype.$coffeeHubConnection.on('Disconnect', () => {
        Vue.prototype.$coffeeHubConnection.stop();
        EventBus.$emit('coffee-hub-disconnect', `Good bye and thank you for the fish!`);
    })

    Vue.prototype.$coffeeHubConnection.start()
        .catch((err: { toString: () => void; }) => console.error(err.toString()));

}