// The MIT License (MIT)
// 
// Copyright (c) Andrew Armstrong/FacticiusVir 2017
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

// This file was automatically generated and should not be edited directly.

using System;

namespace SharpVk
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Buffer
    {
        internal readonly SharpVk.Interop.Buffer handle; 
        
        private readonly SharpVk.Interop.Device parent; 
        
        internal Buffer(SharpVk.Interop.Device parent, SharpVk.Interop.Buffer handle)
        {
            this.handle = handle;
            this.parent = parent;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public unsafe MemoryRequirements GetMemoryRequirements()
        {
            try
            {
                MemoryRequirements result = default(MemoryRequirements);
                MemoryRequirements marshalledMemoryRequirements = default(MemoryRequirements);
                Interop.Commands.vkGetBufferMemoryRequirements(this.parent, this.handle, &marshalledMemoryRequirements);
                result = marshalledMemoryRequirements;
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public unsafe void BindMemory(DeviceMemory memory, DeviceSize memoryOffset)
        {
            try
            {
                Result methodResult = Interop.Commands.vkBindBufferMemory(this.parent, this.handle, memory.handle, memoryOffset);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public unsafe void Destroy(AllocationCallbacks? allocator = null)
        {
            try
            {
                Interop.AllocationCallbacks* marshalledAllocator = default(Interop.AllocationCallbacks*);
                if (allocator != null)
                {
                    marshalledAllocator = (Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<Interop.AllocationCallbacks>());
                    allocator.Value.MarshalTo(marshalledAllocator);
                }
                Interop.Commands.vkDestroyBuffer(this.parent, this.handle, marshalledAllocator);
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
    }
}