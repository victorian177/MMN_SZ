from pyedflib import EdfReader
import os
import numpy as np

def make_path(root_path,subject_id=1,trial=1,phase=4):
    return root_path+'/'+str(subject_id)+'/'+str(trial)+'/'+'Phase '+str(phase)+'.edf'

def xtract_subject_trial(root_path,subject_id,trial):
    if trial!= 'userfile.gnr':
        data=dict.fromkeys([1,2,3,4])
        for phase in data.keys():
            temp = EdfReader(make_path(root_path,int(subject_id),int(trial),int(phase)))
            no_chs = temp.signals_in_file
            assert np.array_equal(temp.getNSamples(),temp.getNSamples())
            N=temp.getNSamples()[0]
            assert np.array_equal(temp.getSampleFrequencies(),temp.getSampleFrequencies())
            Fs=temp.getSampleFrequencies()[0]
            data[phase]=np.empty((0,N))
            for ch in range(no_chs):
                data[phase]=np.vstack((data[phase],temp.readSignal(ch)))
        temp.close()
        return data
    else:
        return None

def xtract_subject_all_trials(root_path,subject_id):
    all_trials=list()
    for trial in os.listdir(root_path+'/'+str(subject_id)):
        if trial != 'userfile.gnr':
            all_trials.append(xtract_subject_trial(root_path,subject_id,int(trial)))
    return all_trials

def xtract_all_subjects(root_path):
    all_subjects_data=list()
    for subject in os.listdir(root_path):
        all_subjects_data.append(xtract_subject_all_trials(root_path,int(subject)))
    return all_subjects_data

class annotationXtractor():
    def __init__(self):
        None
    
    def subject_trial(self,root_path,subject_id,trial):
        if trial!= 'userfile.gnr':
            annotns=dict.fromkeys([1,2,3,4])
            for phase in annotns.keys():
                temp = EdfReader(make_path(root_path,int(subject_id),int(trial),int(phase)))
                annot = temp.readAnnotations()
                annotns[phase] = np.vstack((annot[0],annot[2]))
            return annotns
        else:
            return None

    def subject_all_trials(self,root_path,subject_id):
        all_trials=list()
        for trial in os.listdir(root_path+'/'+str(subject_id)):
            if trial != 'userfile.gnr':
                all_trials.append(self.subject_trial(root_path,subject_id,int(trial)))
        return all_trials

    def all_subjects(self,root_path):
        all_subjects_data=list()
        for subject in os.listdir(root_path):
            all_subjects_data.append(self.subject_all_trials(root_path,int(subject)))
        return all_subjects_data

