from pyedflib import EdfReader
import os
import numpy as np

def make_path(root_path,subject_id=1,trial=1,phase=4):
    return root_path+str(subject_id)+'/'+str(trial)+'/'+'Phase '+str(phase)+'.edf'

def xtract_id_subject_info_dict(dir):
    subject_ids =os.listdir(dir)
    id_subject_dict = dict() 
    for id in subject_ids:
        with open(dir+id+'/'+'userfile.gnr','rb') as gnr:
            gnr_content = gnr.read()
            index = list()
            for i,b in enumerate(gnr_content):
                if b == 0x0A:
                    index.append(i)
            name = str(gnr_content[index[0]+11:index[1]-1])[2:-1] + \
                ' ' + str(gnr_content[index[1]+9:index[2]-1])[2:-1]
            age = str(gnr_content[index[2]+5:index[3]-1])[2:-1]
            sex = str(gnr_content[index[3]+5:index[4]-1])[2:-1]
            category = str(gnr_content[index[4]+10:index[5]-1])[2:-1]
        id_subject_dict[id] = {
            'name':name,
            'age':int(age),
            'sex':sex,
            'category':category,
            'eeg_data':xtract_subject_all_trials(dir,id),
            'eeg_markers':subject_all_marker_trials(dir,id),
        }
    return id_subject_dict
    

def xtract_subject_trial(root_path,subject_id,trial):
    if trial!= 'userfile.gnr':
        data=dict.fromkeys([1,2,3,4])
        for phase in data.keys():
            try:
                temp = EdfReader(make_path(root_path,int(subject_id),int(trial),int(phase)))
                no_chs = temp.signals_in_file
                assert np.array_equal(temp.getNSamples(),temp.getNSamples())
                N=temp.getNSamples()[0]
                assert np.array_equal(temp.getSampleFrequencies(),temp.getSampleFrequencies())
                Fs=temp.getSampleFrequencies()[0]
                data[phase]=np.empty((0,N))
                for ch in range(no_chs):
                    data[phase]=np.vstack((data[phase],temp.readSignal(ch)))
                temp_exist=True
            except OSError:
                temp_exist=False
                data[phase] = np.empty((0,0,0))
        if temp_exist == True:
            temp.close()
        return data
    else:
        return None

def xtract_subject_all_trials(root_path,subject_id):
    all_trials={
        'rest1':list(),
        'arith':list(),
        'rest2':list(),
        'auditory':list(),
        }
    for trial in os.listdir(root_path+'/'+str(subject_id)):
        if trial != 'userfile.gnr':
            trial = xtract_subject_trial(root_path,subject_id,int(trial))
            all_trials['rest1'].append(trial[1])
            all_trials['arith'].append(trial[2])
            all_trials['rest2'].append(trial[3])
            all_trials['auditory'].append(trial[4])
    return all_trials

# def xtract_all_subjects(root_path):
#     all_subjects_data=list()
#     for subject in os.listdir(root_path):
#         all_subjects_data.append(xtract_subject_all_trials(root_path,int(subject)))
#     return all_subjects_data

# class annotationXtractor():
#     def __init__(self):
#         None
    
def subject_marker_trial(root_path,subject_id,trial):
    if trial!= 'userfile.gnr':
        annotns=dict.fromkeys([1,2,3,4])
        for phase in annotns.keys():
            try:
                temp = EdfReader(make_path(root_path,int(subject_id),int(trial),int(phase)))
                annot = temp.readAnnotations()
                annotns[phase] = np.vstack((annot[0],annot[2]))
                temp_exist = True
            except OSError:
                temp_exist = False
                annotns[phase] = np.empty((0,0,0))
        if temp_exist == True:
            temp.close()
        return annotns

def subject_all_marker_trials(root_path,subject_id):
    all_markers={
        'rest1':list(),
        'arith':list(),
        'rest2':list(),
        'auditory':list(),
        }
    for trial in os.listdir(root_path+str(subject_id)):
        if trial != 'userfile.gnr':
            marker = subject_marker_trial(root_path,subject_id,int(trial))
            all_markers['rest1'].append(marker[1])
            all_markers['arith'].append(marker[2])
            all_markers['rest2'].append(marker[3])
            all_markers['auditory'].append(marker[4])
    return all_markers

    # def all_subjects(self,root_path):
    #     all_subjects_data=list()
    #     for subject in os.listdir(root_path):
    #         all_subjects_data.append(self.subject_all_trials(root_path,int(subject)))
    #     return all_subjects_data

