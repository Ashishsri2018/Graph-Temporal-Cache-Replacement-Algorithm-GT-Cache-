initialize: cache = empty set, graph = empty map of (node→neighbor:weight)
last_item = null
on request(item):
    // Update graph with transition from last_item to item
    if last_item is not null:
        w = graph.get_or_insert(last_item, item, 0)
        graph[last_item][item] = w + 1
        // Decay all edges by factor 0<d<1 (e.g., d=0.99) to age old data
        for each (u→v) in graph:
            graph[u][v] *= decay_factor  

    last_item = item

    if item is in cache:
        // Cache hit: nothing else needed (could update recency if used)
        return

    // Cache miss: need to insert item
    if cache.size < MAX_CACHE_SIZE:
        cache.insert(item)
        return

    // Compute scores for eviction candidates
    best_score = +∞
    victim = null
    for each c in cache:
        // Score = sum of weights of edges incident on c
        score = 0
        for each neighbor, w in graph.get_neighbors(c):
            score += w
        for each u such that graph[u][c] exists:
            score += graph[u][c]
        // Optionally add recency penalty: score -= lambda * (current_time - last_access_time[c])
        if score < best_score:
            best_score = score
            victim = c

    // Evict least-scored item and insert new
    cache.remove(victim)
    cache.insert(item)
