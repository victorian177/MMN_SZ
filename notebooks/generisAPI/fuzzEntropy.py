class fuzzEntropy:
    def __init__(self,window_size,dissimilarity_index,membership_function):
        self.m = self.window_size = window_size
        self.r = self.dissimilarity_index = dissimilarity_index
        self.mu = self.membership_function = membership_function
    
    def __computeUmatrix(self,X):
        N = X.shape[0]
        m = self.m

        U = [X[i:i+m-1].tolist() for i in range(0,N-m+1)]