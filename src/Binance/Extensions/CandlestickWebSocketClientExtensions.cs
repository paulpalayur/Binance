﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Binance.Market;
using Binance.WebSocket.Events;

// ReSharper disable once CheckNamespace
namespace Binance.WebSocket
{
    public static class CandlestickWebSocketClientExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="symbol"></param>
        /// <param name="interval"></param>
        public static void Subscribe(this ICandlestickWebSocketClient client, string symbol, CandlestickInterval interval)
            => client.Subscribe(symbol, interval, null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="symbol"></param>
        /// <param name="interval"></param>
        public static void Unsubscribe(this ICandlestickWebSocketClient client, string symbol, CandlestickInterval interval)
            => client.Unsubscribe(symbol, interval, null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static Task StreamAsync(this ICandlestickWebSocketClient client, CancellationToken token)
        {
            Throw.IfNull(client, nameof(client));

            return client.WebSocket.StreamAsync(token);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="symbol"></param>
        /// <param name="interval"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static Task SubscribeAndStreamAsync(this ICandlestickWebSocketClient client, string symbol, CandlestickInterval interval, CancellationToken token)
            => SubscribeAndStreamAsync(client, symbol, interval, null, token);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="symbol"></param>
        /// <param name="interval"></param>
        /// <param name="callback"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static Task SubscribeAndStreamAsync(this ICandlestickWebSocketClient client, string symbol, CandlestickInterval interval, Action<CandlestickEventArgs> callback, CancellationToken token)
        {
            Throw.IfNull(client, nameof(client));

            client.Subscribe(symbol, interval, callback);

            return StreamAsync(client, token);
        }
    }
}
