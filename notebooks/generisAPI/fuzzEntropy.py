import numpy as np

class gaussianMembershipfunction:
    def __init__(self,std,mean=0):
        self.c = self.mean = mean
        self.sigma = self.std = std

    def fuzzyValue(self,x):
        return np.exp(-0.5*((x-self.mean)/self.std)**2)

class fuzzEntropy:
    def __init__(self,window_size,dissimilarity_index,membership_function):
        self.m = self.window_size = window_size
        self.r = self.dissimilarity_index = dissimilarity_index
        self.mu = self.membership_function = membership_function
    
    def __computeFuzzyMatrix(self,x,m):
        N = x.shape[0]

        X = np.array([x[i:i+m-1].tolist() for i in range(0,N-m)])
        U0 = np.repeat(np.sum(X,axis=1),m-1).reshape(X.shape[0],X.shape[1])

        Xm = X - U0

        d=list()
        for i in range(N-m):
            tmp=list()
            for j in range(N-m):
                if i != j:
                    tmp.append((X[i,:]-X[j,:]).tolist())
            d.append(tmp)
        dm = np.array(d).max(axis=2)

        Dm = self.mu(self.r).fuzzyValue(dm)

        phim = (1/(N-m-1)) * np.sum(Dm,axis=1)

        return phim
    
    def fuzzyEntropyCompute(self,x):
        N = x.shape[0]
        phim = self.__computeFuzzyMatrix(x,self.m)
        phim1 = self.__computeFuzzyMatrix(x,self.m+1)

        psim = (1/(N-self.m)) * np.sum(phim,axis=0)
        psim1 = (1/(N-self.m)) * np.sum(phim1,axis=0)
        
        return np.log(psim)-np.log(psim1)