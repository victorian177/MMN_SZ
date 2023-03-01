import numpy as np
import mne
import math
import EntropyHub

def xtract_phase_data(phase,data):
    res=dict()
    for s in data:
        res[s]=dict()
        res[s]['eeg_data'] = data[s]['eeg_data'][phase]
        res[s]['eeg_markers'] = data[s]['eeg_markers'][phase]
    return res

class trial_epoching:
    def __init__(self,dummy=0):
        pass

    def fit_transform(self,X):
        if (X.shape[1] < 200) or (X.shape[1]%2 != 0):
            print('beta',X.shape)
            return X
        else:
            for i in range(15,0,-1):
                if X.shape[1]%i == 0:
                    x=X.reshape(i,X.shape[0],int(X.shape[1]/i))
                    break
            return x

class trial_averaging:
    def __init__(self,axis=0,dummy=0):
        self.axis=axis

    def fit_transform(self,X):
        return np.average(X,self.axis)


class stft:
    def __init__(self,fs,sfreq):
        self.fs=fs
        self.w = (fs-1)*2
        self.f = mne.time_frequency.stftfreq(self.w,sfreq)

    def __stft(self,x):
        return mne.time_frequency.stft(x,self.w)

    def fit_transform(self,X):
        if X.ndim==2:
            return self.__stft(X)
        elif X.ndim==3:
            res=np.empty((X.shape[0],X.shape[1],self.fs,math.ceil(X.shape[2]*2/self.w)))
            for i in range(X.shape[0]):
                res[i,:,:,:] = self.__stft(X[i,:,:])
        return res

class fuzzEnt:
    def __init__(self,m):
        self.m = m

    def fit_transform(self,X):
        if X.ndim == 3:
            res=np.empty((1))
            for e in X:
                if e.shape[-1] > 126:
                    for i in range(30,1,-1):
                        if e.shape[-1]%i==0 and e.shape[-1]/i<=126:
                            break
                    cnt=int(e.shape[-1]/i)
                    ent = EntropyHub.FuzzEn2D(e[:,0:cnt],self.m)
                    for c in range(1,i):
                        ent += EntropyHub.FuzzEn2D(e[:,c*cnt:(c+1)*cnt],self.m)
                else:
                    ent=EntropyHub.FuzzEn2D(e,self.m,Lock=False)
                res=np.append(res,ent)
            return res
        elif X.ndim == 2:
            return EntropyHub.FuzzEn2D(X,self.m,Lock=False)

def phase_trials_processor(pipeline,phase):
    res=[]
    for t in phase:
        if t.shape != (0,0,0):
            res.append(pipeline.fit_transform(t))
    return res
    
def all_subjects(pipeline,data):
    res=dict()
    for s in data:
        res[s] = phase_trials_processor(pipeline,data[s]['eeg_data'])
        print(s)
    return res