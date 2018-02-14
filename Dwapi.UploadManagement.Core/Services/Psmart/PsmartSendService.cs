﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Dwapi.SharedKernel.DTOs;
using Dwapi.SharedKernel.Utility;
using Dwapi.UploadManagement.Core.Interfaces.Services.Psmart;
using Dwapi.UploadManagement.Core.Model;
using Serilog;

namespace Dwapi.UploadManagement.Core.Services.Psmart
{
    public class PsmartSendService: IPsmartSendService
    {
        private readonly string _endPoint;

        public PsmartSendService()
        {
            _endPoint = "api/v1/inbound";
        }

        public async Task<SendResponse> SendAsync(SendPackageDTO sendTo, PsmartMessage psmartMessage)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("SubscriberId", $"{sendTo.Destination.SubscriberId}");
            if (sendTo.Destination.RequiresAuthentication())
            {
                client.DefaultRequestHeaders.Add("Token", $"{sendTo.Destination.AuthToken}");
            }

            var response = await client.PostAsJsonAsync(sendTo.GetUrl(_endPoint), psmartMessage);
            SendResponse content = null;
            if (null != response&&response.IsSuccessStatusCode)
            {
                try
                {
                    content = await response.Content.ReadAsJsonAsync<SendResponse>();
                }
                catch (Exception e)
                {
                    // send error
                    Log.Debug($"{e}");
                }
            }
            return content;
        }


        public async Task<SendResponse> SendAsync(SendPackageDTO sendTo, IEnumerable<PsmartStageDTO> message)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("SubscriberId", $"{sendTo.Destination.SubscriberId}");
            if (sendTo.Destination.RequiresAuthentication())
            {
                client.DefaultRequestHeaders.Add("Token", $"{sendTo.Destination.AuthToken}");
            }

            var response = await client.PostAsJsonAsync(sendTo.GetUrl(_endPoint), message);
            SendResponse content = null;
            if (null != response)
            {
                try
                {
                    content = await response.Content.ReadAsJsonAsync<SendResponse>();
                }
                catch (Exception e)
                {
                    // send error
                    Log.Debug($"{e}");
                }
            }
            return content;
        }

        public async Task<SendResponse> SendToRegistryAsync(SendPackageDTO sendTo, IEnumerable<PsmartMessage> message)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("SubscriberId", $"{sendTo.Destination.SubscriberId}");
            if (sendTo.Destination.RequiresAuthentication())
            {
                client.DefaultRequestHeaders.Add("Token", $"{sendTo.Destination.AuthToken}");
            }

            var response = await client.PostAsJsonAsync(sendTo.GetUrl(_endPoint), message);
            SendResponse content = null;
            if (null != response)
            {
                try
                {
                    content = await response.Content.ReadAsJsonAsync<SendResponse>();
                }
                catch (Exception e)
                {
                    // send error
                    Log.Debug($"{e}");
                }
            }
            return content;
        }
    }
}