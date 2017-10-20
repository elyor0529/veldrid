﻿using System;

namespace Vd2
{
    public struct OutputDescription
    {
        public OutputAttachmentDescription? DepthAttachment;
        public OutputAttachmentDescription[] ColorAttachments;

        public OutputDescription(OutputAttachmentDescription? depthAttachment, params OutputAttachmentDescription[] colorAttachments)
        {
            DepthAttachment = depthAttachment;
            ColorAttachments = colorAttachments ?? Array.Empty<OutputAttachmentDescription>();
        }

        internal static OutputDescription CreateFromFramebuffer(Framebuffer fb)
        {
            OutputAttachmentDescription? depthAttachment = null;
            if (fb.DepthTexture != null)
            {
                depthAttachment = new OutputAttachmentDescription(fb.DepthTexture.Format);
            }
            OutputAttachmentDescription[] colorAttachments = new OutputAttachmentDescription[fb.ColorTextures.Count];
            for (int i = 0; i < colorAttachments.Length; i++)
            {
                colorAttachments[i] = new OutputAttachmentDescription(fb.ColorTextures[i].Format);
            }

            return new OutputDescription(depthAttachment, colorAttachments);
        }
    }
}