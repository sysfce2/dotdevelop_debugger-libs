// 
// EvaluationOptions.cs
//  
// Author:
//       Lluis Sanchez Gual <lluis@novell.com>
// 
// Copyright (c) 2009 Novell, Inc (http://www.novell.com)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;

namespace Mono.Debugging.Client
{
	[Serializable]
	public struct EvaluationOptions
	{
		bool allowMethodEvaluation;
		bool allowToStringCalls;
		
		public static EvaluationOptions DefaultOptions {
			get {
				EvaluationOptions ops = new EvaluationOptions ();
				ops.EvaluationTimeout = 1000;
				ops.MemberEvaluationTimeout = 5000;
				ops.AllowTargetInvoke = true;
				ops.AllowMethodEvaluation = true;
				ops.AllowToStringCalls = true;
				return ops;
			}
		}
		
		public int EvaluationTimeout { get; set; }
		public int MemberEvaluationTimeout { get; set; }
		public bool AllowTargetInvoke { get; set; }
		
		public bool AllowMethodEvaluation {
			get { return allowMethodEvaluation && AllowTargetInvoke; }
			set { allowMethodEvaluation = value; }
		}
		
		public bool AllowToStringCalls {
			get { return allowToStringCalls && AllowTargetInvoke; }
			set { allowToStringCalls = value; }
		}
		
		public bool AllowDisplayStringEvaluation {
			get { return AllowTargetInvoke; }
		}
		
		public bool AllowDebuggerProxy {
			get { return AllowTargetInvoke; }
		}
	}
}