import numpy as np

class MMN:
    def __init__(self,delay=10,position=40,window_size=20):
        self.d = delay
        self.p = position
        self.w = window_size
    
    def mmn_value(self,x):
        if x.ndim == 1:
            return np.mean(x[self.p-self.d:self.p-self.d+self.w])
        elif x.ndim == 2:
            return np.mean(x[:,self.p-self.d:self.p-self.d+self.w],axis=1)
        

# def mmn_value(time_series, deviant_position, standard_position, window_size, delay):
#     """
#     Computes the Mismatch Negativity (MMN) value from a time series
#     :param time_series: 1D numpy array containing the time series data
#     :param deviant_position: the position of the deviant stimulus in the time series
#     :param standard_position: the position of the standard stimulus in the time series
#     :param window_size: the size of the temporal window used for analysis in milliseconds
#     :param delay: the delay in milliseconds between the deviant and standard stimuli
#     :return: the MMN value
#     """
#     deviant_window = time_series[deviant_position-delay:deviant_position-delay+window_size]
#     standard_window = time_series[standard_position-delay:standard_position-delay+window_size]
#     mmn = np.mean(deviant_window) - np.mean(standard_window)
#     return mmn