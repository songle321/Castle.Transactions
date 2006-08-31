// Copyright 2004-2006 Castle Project - http://www.castleproject.org/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Castle.Core
{
	using System;
	using System.Collections;
    using System.Reflection;

	/// <summary>
	/// Collection of <see cref="ConstructorCandidate"/>
	/// </summary>
	[Serializable]
	public class ConstructorCandidateCollection : ReadOnlyCollectionBase
	{
		private ConstructorCandidate fewerArgumentsCandidate;
		private ConstructorCandidate bestCandidate;

		public void Add(ConstructorCandidate candidate)
		{
			if (fewerArgumentsCandidate == null)
			{
				fewerArgumentsCandidate = candidate;
			}
			else
			{
				if (candidate.Constructor.GetParameters().Length < 
					fewerArgumentsCandidate.Constructor.GetParameters().Length)
				{
					fewerArgumentsCandidate = candidate;
				}
			}

			InnerList.Add(candidate);
		}

		public ConstructorCandidate FewerArgumentsCandidate
		{
			get { return fewerArgumentsCandidate; }
		}

		public ConstructorCandidate BestCandidate
		{
			get { return bestCandidate; }
			set { bestCandidate = value; }
		}

		public void Clear()
		{
			InnerList.Clear();
		}
	}
}