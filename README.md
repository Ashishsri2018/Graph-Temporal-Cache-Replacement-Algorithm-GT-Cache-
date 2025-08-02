# Graph-Temporal-Cache-Replacement-Algorithm-GT-Cache-


ChatGPT
You said:
Invent a new classical computing algorithm that's unique and didn't exist yet. No quantum, any programming language, core idea should be unique. Double check on the Internet that the topic you choose is unique and doesn't exists already.
ChatGPT said:
To ensure the algorithm I invent is truly unique, could you share the general area you're interested in? For example:

Sorting

Graph traversal

Compression

Cryptography

Machine learning / AI

Data structures

Parallel computing

String algorithms

Numerical computing / optimization

Something else?

Also, are you more interested in theoretical novelty, practical usefulness, or both?

You said:
Chose anything, but should be new and unique 
ChatGPT said:
Great, I’ll create a novel classical computing algorithm that is both theoretically interesting and practically implementable, and verify its uniqueness by checking existing research and algorithms online. I’ll focus on a niche not fully explored—likely in an intersectional area like hybrid data structures or dynamic caching techniques.

I’ll let you know once I’ve completed the research and confirmed the idea is indeed original.

Research completed in 7m · 14 sources · 130 searches
Novel Classical Computing Algorithm Verification for Uniqueness

Graph-Temporal Cache Replacement Algorithm (GT-Cache)
Problem Context
Modern distributed and edge caching systems must efficiently decide what content to store and evict under highly dynamic workloads. Traditional policies like LRU or LFU focus only on recency or frequency
journalofcloudcomputing.springeropen.com
. Recent work has begun using hybrid or learning-based methods (e.g. ARC, TTL-tuning, or ML prediction
arxiv.org
journalofcloudcomputing.springeropen.com
) to handle complex patterns. Graph-based caching has also been explored: for example, information-centric networks use content-centric centrality (NICE
conferences.sigcomm.org
conferences.sigcomm.org
) and edge networks may use collaborative centrality
conferences.sigcomm.org
. Other research mines offline correlations (association rules
arxiv.org
) or uses SSL/ML for edge caching
journalofcloudcomputing.springeropen.com
. However, there is a gap in purely classical, online algorithms that exploit the sequential co-access graph of items with temporal decay and lightweight scoring. Edge/IoT scenarios in particular demand a fast, memory-light strategy
arxiv.org
. We therefore identify the need for a cache policy that adaptively combines recent access patterns (captured in a graph) with aging to make eviction decisions.
Novel Algorithm Description
We propose GT-Cache, a novel cache replacement algorithm that maintains an online directed graph of item co-accesses and uses it (with temporal decay) to score cached items. Each node is a content item; when an access sequence has item A followed by B, we add/increment a directed edge A→B. All edge weights decay gradually (e.g. multiply by a factor <1 on each access). Thus the graph emphasizes recent sequential patterns while fading old data. When a cache miss occurs and the cache is full, GT-Cache computes a score for each cached item by summing its incident edge weights in this graph (incoming and outgoing). Intuitively, an item with many strong edges to/from recently accessed items has higher score (it is part of a hot sequence), while isolated or stale items have low score. GT-Cache evicts the cached item with the lowest score. (Tie-breaking can use recency/time.) This hybrid graph-based score combines both frequency of transitions and recency via decay. Unlike static association-rule mining
arxiv.org
 or heavy ML models
journalofcloudcomputing.springeropen.com
, GT-Cache builds the co-access graph on the fly with simple integer weights and periodic decay. It requires only O(|E|) updates per access (where |E| is the number of edges from the last accessed item) and O(C) scoring for a cache of size C. In effect, GT-Cache generalizes LRU/LFU: if edges decay to zero, it behaves like LRU/LFU, but it can capture patterns like “A→B→C” so that once A and B are seen, C is pre-favored. GT-Cache’s core novelty is this temporal co-access graph heuristic. To our knowledge no prior algorithm in the literature explicitly uses a decaying directed co-access graph for replacement decisions. Existing graph-based policies in Information-Centric Networks use static network centrality
conferences.sigcomm.org
conferences.sigcomm.org
 or require global knowledge
conferences.sigcomm.org
, whereas GT-Cache is fully online and local. Compared to correlation-based caching
arxiv.org
, GT-Cache does not need an offline mining pass. And unlike ML-driven edge caching
journalofcloudcomputing.springeropen.com
, GT-Cache remains a lightweight, implementable algorithm (suitable for edge caches
arxiv.org
).
