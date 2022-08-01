<?xml version='1.0' encoding='utf-8'?>
<scheme description="" title="MMN_SZ_data_preprocessing" version="2.0">
	<nodes>
		<node id="0" name="Import EDF" position="(547.0, 359.0)" project_name="NeuroPype" qualified_name="widgets.file_system.owimportedf.OWImportEDF" title="Import EDF" uuid="861f2419-3dad-4df1-9d56-933c86ac1462" version="1.1.0" />
		<node id="1" name="Stream Data" position="(648.0, 359.0)" project_name="NeuroPype" qualified_name="widgets.formatting.owstreamdata.OWStreamData" title="Stream Data" uuid="586f3452-d1a2-4070-83c0-6ef23bba88e0" version="1.1.0" />
		<node id="2" name="IIR Filter" position="(740.0, 373.0)" project_name="NeuroPype" qualified_name="widgets.signal_processing.owiirfilter.OWIIRFilter" title="IIR Filter" uuid="130debde-8d97-4335-9baa-0220d6e600f9" version="1.1.0" />
		<node id="3" name="Segmentation" position="(837.0, 373.0)" project_name="NeuroPype" qualified_name="widgets.formatting.owsegmentation.OWSegmentation" title="Segmentation" uuid="13fd1e95-93eb-4a06-b039-7c83959efd10" version="1.0.1" />
		<node id="4" name="Batch Instances" position="(941.0, 373.0)" project_name="NeuroPype" qualified_name="widgets.formatting.owbatchinstances.OWBatchInstances" title="Batch Instances" uuid="d6f62f3a-ed3b-43d7-8840-0ae046aa8b39" version="0.5.1" />
		<node id="5" name="Record to XDF" position="(1050.0, 373.0)" project_name="NeuroPype" qualified_name="widgets.file_system.owrecordtoxdf.OWRecordToXDF" title="Record to XDF" uuid="fbb5800b-9344-404a-af86-ce6aa67f4f20" version="1.0.0" />
		<node id="6" name="Time Series Plot" position="(761.0, 246.0)" project_name="NeuroPype" qualified_name="widgets.visualization.owtimeseriesplot.OWTimeSeriesPlot" title="Time Series Plot(pre_filtered_data)" uuid="c7755184-f2fd-4853-9a0d-1eeb50294e7f" version="1.0.1" />
		<node id="7" name="Time Series Plot" position="(844.0, 494.0)" project_name="NeuroPype" qualified_name="widgets.visualization.owtimeseriesplot.OWTimeSeriesPlot" title="Time Series Plot(filtered_data)" uuid="cc60aa6c-5c5b-4bbd-8aa6-5e242fcaffba" version="1.0.1" />
	</nodes>
	<links>
		<link enabled="true" id="0" sink_channel="Data" sink_node_id="1" source_channel="Data" source_node_id="0" />
		<link enabled="true" id="1" sink_channel="Data" sink_node_id="2" source_channel="Data" source_node_id="1" />
		<link enabled="true" id="2" sink_channel="Data" sink_node_id="4" source_channel="Data" source_node_id="3" />
		<link enabled="true" id="3" sink_channel="Data" sink_node_id="5" source_channel="Data" source_node_id="4" />
		<link enabled="true" id="4" sink_channel="Data" sink_node_id="6" source_channel="Data" source_node_id="1" />
		<link enabled="true" id="5" sink_channel="Data" sink_node_id="7" source_channel="Data" source_node_id="2" />
		<link enabled="true" id="6" sink_channel="Data" sink_node_id="3" source_channel="Data" source_node_id="2" />
	</links>
	<annotations />
	<thumbnail />
	<node_properties>
		<properties format="pickle" node_id="0">gAN9cQAoWA0AAABjbG91ZF9hY2NvdW50cQFYAAAAAHECWAwAAABjbG91ZF9idWNrZXRxA2gCWBEA
AABjbG91ZF9jcmVkZW50aWFsc3EEaAJYCgAAAGNsb3VkX2hvc3RxBVgHAAAARGVmYXVsdHEGWAgA
AABmaWxlbmFtZXEHWCgAAABEOi9FbW1hbnVlbF9wZXRyb25fT2xhdGVqdS9NTU5fU1ovMTUuZWRm
cQhYEwAAAHNhdmVkV2lkZ2V0R2VvbWV0cnlxCWNzaXAKX3VucGlja2xlX3R5cGUKcQpYDAAAAFB5
UXQ0LlF0Q29yZXELWAoAAABRQnl0ZUFycmF5cQxDLgHZ0MsAAQAAAAADAwAAAYAAAAR8AAACmgAA
AwwAAAGmAAAEcwAAApEAAAAAAABxDYVxDodxD1JxEFgOAAAAc2V0X2JyZWFrcG9pbnRxEYlYDAAA
AHN0aW1fY2hhbm5lbHESaAJ1Lg==
</properties>
		<properties format="literal" node_id="1">{'hitch_probability': 0.0, 'jitter_percent': 5, 'looping': True, 'randseed': 34535, 'savedWidgetGeometry': None, 'set_breakpoint': False, 'speedup': 1.0, 'start_pos': 0.0, 'timestamp_jitter': 0.0, 'timing': 'wallclock', 'update_interval': 0.04}</properties>
		<properties format="pickle" node_id="2">gAN9cQAoWAQAAABheGlzcQFYBAAAAHRpbWVxAlgGAAAAZGVzaWducQNYBgAAAGJ1dHRlcnEEWAsA
AABmcmVxdWVuY2llc3EFXXEGKEc/uZmZmZmZmksBS2RHQFk5mZmZmZplWAsAAABpZ25vcmVfbmFu
c3EHiVgEAAAAbW9kZXEIWAgAAABiYW5kcGFzc3EJWBAAAABvZmZsaW5lX2ZpbHRmaWx0cQqJWAUA
AABvcmRlcnELWA0AAAAodXNlIGRlZmF1bHQpcQxYCQAAAHBhc3NfbG9zc3ENR0AIAAAAAAAAWBMA
AABzYXZlZFdpZGdldEdlb21ldHJ5cQ5jc2lwCl91bnBpY2tsZV90eXBlCnEPWAwAAABQeVF0NC5R
dENvcmVxEFgKAAAAUUJ5dGVBcnJheXERQy4B2dDLAAEAAAAAAwMAAAGoAAAEfAAAAnIAAAMMAAAB
zgAABHMAAAJpAAAAAAAAcRKFcROHcRRScRVYDgAAAHNldF9icmVha3BvaW50cRaJWAoAAABzdG9w
X2F0dGVucRdHQEkAAAAAAAB1Lg==
</properties>
		<properties format="pickle" node_id="3">gAN9cQAoWBEAAABrZWVwX21hcmtlcl9jaHVua3EBiVgOAAAAbWF4X2dhcF9sZW5ndGhxAkc/yZmZ
mZmZmlgPAAAAb25saW5lX2Vwb2NoaW5ncQNYDQAAAG1hcmtlci1sb2NrZWRxBFgNAAAAc2FtcGxl
X29mZnNldHEFSwBYEwAAAHNhdmVkV2lkZ2V0R2VvbWV0cnlxBmNzaXAKX3VucGlja2xlX3R5cGUK
cQdYDAAAAFB5UXQ0LlF0Q29yZXEIWAoAAABRQnl0ZUFycmF5cQlDLgHZ0MsAAQAAAAADAwAAAYIA
AAR8AAACtwAAAwwAAAGoAAAEcwAAAq4AAAAAAABxCoVxC4dxDFJxDVgOAAAAc2VsZWN0X21hcmtl
cnNxDl1xDyhYBgAAAFRPTkVfQXEQWAYAAABUT05FX0JxEVgGAAAAVE9ORV9DcRJlWA4AAABzZXRf
YnJlYWtwb2ludHETiVgLAAAAdGltZV9ib3VuZHNxFF1xFShLAEc/uZmZmZmZmmVYBwAAAHZlcmJv
c2VxFol1Lg==
</properties>
		<properties format="pickle" node_id="4">gAN9cQAoWAgAAABncm91cF9ieXEBXXECWBEAAABoYW5kbGVfb3Zlcmxlbmd0aHEDWBIAAAB0cnVu
Y2F0ZS1ncm91cC1wcmVxBFgMAAAAcGFkX21heGl0ZW1zcQVYDQAAACh1c2UgZGVmYXVsdClxBlgJ
AAAAcGFkX3ZhbHVlcQdHAAAAAAAAAABYEwAAAHNhdmVkV2lkZ2V0R2VvbWV0cnlxCGNzaXAKX3Vu
cGlja2xlX3R5cGUKcQlYDAAAAFB5UXQ0LlF0Q29yZXEKWAoAAABRQnl0ZUFycmF5cQtDLgHZ0MsA
AQAAAAADAwAAAY0AAAR8AAACjQAAAwwAAAGzAAAEcwAAAoQAAAAAAABxDIVxDYdxDlJxD1gOAAAA
c2V0X2JyZWFrcG9pbnRxEIlYDQAAAHZlcmlmeV91bmlxdWVxEV1xEnUu
</properties>
		<properties format="literal" node_id="5">{'allow_double': False, 'close_on_marker': 'close-recording', 'cloud_account': '', 'cloud_bucket': '', 'cloud_credentials': '', 'cloud_host': 'Default', 'cloud_partsize': 30, 'delete_parts': True, 'filename': 'untitled.xdf', 'output_root': '', 'retrievable': False, 'savedWidgetGeometry': None, 'session_notes': '', 'set_breakpoint': False, 'verbose': False}</properties>
		<properties format="pickle" node_id="6">gAN9cQAoWA0AAABhYnNvbHV0ZV90aW1lcQGJWA0AAABhbHdheXNfb25fdG9wcQKJWAsAAABhbnRp
YWxpYXNlZHEDiFgQAAAAYXV0b19saW5lX2NvbG9yc3EEiVgJAAAAYXV0b3NjYWxlcQWIWBAAAABi
YWNrZ3JvdW5kX2NvbG9ycQZYBwAAACNGRkZGRkZxB1gQAAAAZGVjb3JhdGlvbl9jb2xvcnEIWAcA
AAAjMDAwMDAwcQlYCwAAAGRvd25zYW1wbGVkcQqJWAwAAABpbml0aWFsX2RpbXNxC11xDChLMksy
TbwCTfQBZVgKAAAAbGluZV9jb2xvcnENWAcAAAAjMDAwMDAwcQ5YCgAAAGxpbmVfd2lkdGhxD0c/
6AAAAAAAAFgMAAAAbWFya2VyX2NvbG9ycRBYBwAAACNGRjAwMDBxEVgMAAAAbmFuc19hc196ZXJv
cRKJWA4AAABub19jb25jYXRlbmF0ZXETiVgOAAAAb3ZlcnJpZGVfc3JhdGVxFFgNAAAAKHVzZSBk
ZWZhdWx0KXEVWAwAAABwbG90X21hcmtlcnNxFohYCwAAAHBsb3RfbWlubWF4cReJWBMAAABzYXZl
ZFdpZGdldEdlb21ldHJ5cRhjc2lwCl91bnBpY2tsZV90eXBlCnEZWAwAAABQeVF0NC5RdENvcmVx
GlgKAAAAUUJ5dGVBcnJheXEbQy4B2dDLAAEAAAAAAwMAAAEtAAAEfAAAAu0AAAMMAAABUwAABHMA
AALkAAAAAAAAcRyFcR2HcR5ScR9YBQAAAHNjYWxlcSBHP/AAAAAAAABYDgAAAHNldF9icmVha3Bv
aW50cSGJWAwAAABzaG93X3Rvb2xiYXJxIolYCwAAAHN0cmVhbV9uYW1lcSNYDQAAACh1c2UgZGVm
YXVsdClxJFgKAAAAdGltZV9yYW5nZXElRz/wAAAAAAAAWAUAAAB0aXRsZXEmWBAAAABUaW1lIHNl
cmllcyB2aWV3cSdYCgAAAHplcm9fY29sb3JxKFgHAAAAIzdGN0Y3RnEpWAgAAAB6ZXJvbWVhbnEq
iHUu
</properties>
		<properties format="pickle" node_id="7">gAN9cQAoWA0AAABhYnNvbHV0ZV90aW1lcQGJWA0AAABhbHdheXNfb25fdG9wcQKJWAsAAABhbnRp
YWxpYXNlZHEDiFgQAAAAYXV0b19saW5lX2NvbG9yc3EEiVgJAAAAYXV0b3NjYWxlcQWIWBAAAABi
YWNrZ3JvdW5kX2NvbG9ycQZYBwAAACNGRkZGRkZxB1gQAAAAZGVjb3JhdGlvbl9jb2xvcnEIWAcA
AAAjMDAwMDAwcQlYCwAAAGRvd25zYW1wbGVkcQqJWAwAAABpbml0aWFsX2RpbXNxC11xDChLMksy
TbwCTfQBZVgKAAAAbGluZV9jb2xvcnENWAcAAAAjMDAwMDAwcQ5YCgAAAGxpbmVfd2lkdGhxD0c/
6AAAAAAAAFgMAAAAbWFya2VyX2NvbG9ycRBYBwAAACNGRjAwMDBxEVgMAAAAbmFuc19hc196ZXJv
cRKJWA4AAABub19jb25jYXRlbmF0ZXETiVgOAAAAb3ZlcnJpZGVfc3JhdGVxFFgNAAAAKHVzZSBk
ZWZhdWx0KXEVWAwAAABwbG90X21hcmtlcnNxFohYCwAAAHBsb3RfbWlubWF4cReJWBMAAABzYXZl
ZFdpZGdldEdlb21ldHJ5cRhjc2lwCl91bnBpY2tsZV90eXBlCnEZWAwAAABQeVF0NC5RdENvcmVx
GlgKAAAAUUJ5dGVBcnJheXEbQy4B2dDLAAEAAAAAAwMAAAEtAAAEfAAAAu0AAAMMAAABUwAABHMA
AALkAAAAAAAAcRyFcR2HcR5ScR9YBQAAAHNjYWxlcSBHP/AAAAAAAABYDgAAAHNldF9icmVha3Bv
aW50cSGJWAwAAABzaG93X3Rvb2xiYXJxIolYCwAAAHN0cmVhbV9uYW1lcSNYDQAAACh1c2UgZGVm
YXVsdClxJFgKAAAAdGltZV9yYW5nZXElRz/wAAAAAAAAWAUAAAB0aXRsZXEmWBAAAABUaW1lIHNl
cmllcyB2aWV3cSdYCgAAAHplcm9fY29sb3JxKFgHAAAAIzdGN0Y3RnEpWAgAAAB6ZXJvbWVhbnEq
iHUu
</properties>
	</node_properties>
	<patch>{
    "description": {
        "description": "(description missing)",
        "license": "",
        "name": "(untitled)",
        "status": "(unspecified)",
        "url": "",
        "version": "0.0.0"
    },
    "edges": [
        [
            "node1",
            "data",
            "node2",
            "data"
        ],
        [
            "node2",
            "data",
            "node3",
            "data"
        ],
        [
            "node2",
            "data",
            "node7",
            "data"
        ],
        [
            "node4",
            "data",
            "node5",
            "data"
        ],
        [
            "node5",
            "data",
            "node6",
            "data"
        ],
        [
            "node3",
            "data",
            "node8",
            "data"
        ],
        [
            "node3",
            "data",
            "node4",
            "data"
        ]
    ],
    "nodes": {
        "node1": {
            "class": "ImportEDF",
            "module": "neuropype.nodes.file_system.ImportEDF",
            "params": {
                "cloud_account": {
                    "customized": false,
                    "type": "StringPort",
                    "value": ""
                },
                "cloud_bucket": {
                    "customized": false,
                    "type": "StringPort",
                    "value": ""
                },
                "cloud_credentials": {
                    "customized": false,
                    "type": "StringPort",
                    "value": ""
                },
                "cloud_host": {
                    "customized": false,
                    "type": "EnumPort",
                    "value": "Default"
                },
                "filename": {
                    "customized": true,
                    "type": "StringPort",
                    "value": "D:/Emmanuel_petron_Olateju/MMN_SZ/15.edf"
                },
                "set_breakpoint": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "stim_channel": {
                    "customized": false,
                    "type": "StringPort",
                    "value": ""
                }
            },
            "uuid": "861f2419-3dad-4df1-9d56-933c86ac1462"
        },
        "node2": {
            "class": "StreamData",
            "module": "neuropype.nodes.formatting.StreamData",
            "params": {
                "hitch_probability": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": 0.0
                },
                "jitter_percent": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": 5
                },
                "looping": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                },
                "randseed": {
                    "customized": false,
                    "type": "IntPort",
                    "value": 34535
                },
                "set_breakpoint": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "speedup": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": 1.0
                },
                "start_pos": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": 0.0
                },
                "timestamp_jitter": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": 0.0
                },
                "timing": {
                    "customized": false,
                    "type": "EnumPort",
                    "value": "wallclock"
                },
                "update_interval": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": 0.04
                }
            },
            "uuid": "586f3452-d1a2-4070-83c0-6ef23bba88e0"
        },
        "node3": {
            "class": "IIRFilter",
            "module": "neuropype.nodes.signal_processing.IIRFilter",
            "params": {
                "axis": {
                    "customized": false,
                    "type": "EnumPort",
                    "value": "time"
                },
                "design": {
                    "customized": false,
                    "type": "EnumPort",
                    "value": "butter"
                },
                "frequencies": {
                    "customized": true,
                    "type": "ListPort",
                    "value": [
                        0.1,
                        1,
                        100,
                        100.9
                    ]
                },
                "ignore_nans": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "mode": {
                    "customized": false,
                    "type": "EnumPort",
                    "value": "bandpass"
                },
                "offline_filtfilt": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "order": {
                    "customized": false,
                    "type": "IntPort",
                    "value": null
                },
                "pass_loss": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": 3.0
                },
                "set_breakpoint": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "stop_atten": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": 50.0
                }
            },
            "uuid": "130debde-8d97-4335-9baa-0220d6e600f9"
        },
        "node4": {
            "class": "Segmentation",
            "module": "neuropype.nodes.formatting.Segmentation",
            "params": {
                "keep_marker_chunk": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "max_gap_length": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": 0.2
                },
                "online_epoching": {
                    "customized": false,
                    "type": "EnumPort",
                    "value": "marker-locked"
                },
                "sample_offset": {
                    "customized": false,
                    "type": "IntPort",
                    "value": 0
                },
                "select_markers": {
                    "customized": true,
                    "type": "ListPort",
                    "value": [
                        "TONE_A",
                        "TONE_B",
                        "TONE_C"
                    ]
                },
                "set_breakpoint": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "time_bounds": {
                    "customized": true,
                    "type": "ListPort",
                    "value": [
                        0,
                        0.1
                    ]
                },
                "verbose": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                }
            },
            "uuid": "13fd1e95-93eb-4a06-b039-7c83959efd10"
        },
        "node5": {
            "class": "BatchInstances",
            "module": "neuropype.nodes.formatting.BatchInstances",
            "params": {
                "group_by": {
                    "customized": false,
                    "type": "ListPort",
                    "value": []
                },
                "handle_overlength": {
                    "customized": false,
                    "type": "EnumPort",
                    "value": "truncate-group-pre"
                },
                "pad_maxitems": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": null
                },
                "pad_value": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": 0.0
                },
                "set_breakpoint": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "verify_unique": {
                    "customized": false,
                    "type": "ListPort",
                    "value": []
                }
            },
            "uuid": "d6f62f3a-ed3b-43d7-8840-0ae046aa8b39"
        },
        "node6": {
            "class": "RecordToXDF",
            "module": "neuropype.nodes.file_system.RecordToXDF",
            "params": {
                "allow_double": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "close_on_marker": {
                    "customized": false,
                    "type": "StringPort",
                    "value": "close-recording"
                },
                "cloud_account": {
                    "customized": false,
                    "type": "StringPort",
                    "value": ""
                },
                "cloud_bucket": {
                    "customized": false,
                    "type": "StringPort",
                    "value": ""
                },
                "cloud_credentials": {
                    "customized": false,
                    "type": "StringPort",
                    "value": ""
                },
                "cloud_host": {
                    "customized": false,
                    "type": "EnumPort",
                    "value": "Default"
                },
                "cloud_partsize": {
                    "customized": false,
                    "type": "IntPort",
                    "value": 30
                },
                "delete_parts": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                },
                "filename": {
                    "customized": false,
                    "type": "StringPort",
                    "value": "untitled.xdf"
                },
                "output_root": {
                    "customized": false,
                    "type": "StringPort",
                    "value": ""
                },
                "retrievable": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "session_notes": {
                    "customized": false,
                    "type": "StringPort",
                    "value": ""
                },
                "set_breakpoint": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "verbose": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                }
            },
            "uuid": "fbb5800b-9344-404a-af86-ce6aa67f4f20"
        },
        "node7": {
            "class": "TimeSeriesPlot",
            "module": "neuropype.nodes.visualization.TimeSeriesPlot",
            "params": {
                "absolute_time": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "always_on_top": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "antialiased": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                },
                "auto_line_colors": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "autoscale": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                },
                "background_color": {
                    "customized": false,
                    "type": "StringPort",
                    "value": "#FFFFFF"
                },
                "decoration_color": {
                    "customized": false,
                    "type": "StringPort",
                    "value": "#000000"
                },
                "downsampled": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "initial_dims": {
                    "customized": false,
                    "type": "ListPort",
                    "value": [
                        50,
                        50,
                        700,
                        500
                    ]
                },
                "line_color": {
                    "customized": false,
                    "type": "StringPort",
                    "value": "#000000"
                },
                "line_width": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": 0.75
                },
                "marker_color": {
                    "customized": false,
                    "type": "Port",
                    "value": "#FF0000"
                },
                "nans_as_zero": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "no_concatenate": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "override_srate": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": null
                },
                "plot_markers": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                },
                "plot_minmax": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "scale": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": 1.0
                },
                "set_breakpoint": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "show_toolbar": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "stream_name": {
                    "customized": false,
                    "type": "StringPort",
                    "value": null
                },
                "time_range": {
                    "customized": true,
                    "type": "FloatPort",
                    "value": 1.0
                },
                "title": {
                    "customized": false,
                    "type": "StringPort",
                    "value": "Time series view"
                },
                "zero_color": {
                    "customized": false,
                    "type": "StringPort",
                    "value": "#7F7F7F"
                },
                "zeromean": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                }
            },
            "uuid": "c7755184-f2fd-4853-9a0d-1eeb50294e7f"
        },
        "node8": {
            "class": "TimeSeriesPlot",
            "module": "neuropype.nodes.visualization.TimeSeriesPlot",
            "params": {
                "absolute_time": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "always_on_top": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "antialiased": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                },
                "auto_line_colors": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "autoscale": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                },
                "background_color": {
                    "customized": false,
                    "type": "StringPort",
                    "value": "#FFFFFF"
                },
                "decoration_color": {
                    "customized": false,
                    "type": "StringPort",
                    "value": "#000000"
                },
                "downsampled": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "initial_dims": {
                    "customized": false,
                    "type": "ListPort",
                    "value": [
                        50,
                        50,
                        700,
                        500
                    ]
                },
                "line_color": {
                    "customized": false,
                    "type": "StringPort",
                    "value": "#000000"
                },
                "line_width": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": 0.75
                },
                "marker_color": {
                    "customized": false,
                    "type": "Port",
                    "value": "#FF0000"
                },
                "nans_as_zero": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "no_concatenate": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "override_srate": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": null
                },
                "plot_markers": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                },
                "plot_minmax": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "scale": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": 1.0
                },
                "set_breakpoint": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "show_toolbar": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "stream_name": {
                    "customized": false,
                    "type": "StringPort",
                    "value": null
                },
                "time_range": {
                    "customized": true,
                    "type": "FloatPort",
                    "value": 1.0
                },
                "title": {
                    "customized": false,
                    "type": "StringPort",
                    "value": "Time series view"
                },
                "zero_color": {
                    "customized": false,
                    "type": "StringPort",
                    "value": "#7F7F7F"
                },
                "zeromean": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                }
            },
            "uuid": "cc60aa6c-5c5b-4bbd-8aa6-5e242fcaffba"
        }
    },
    "version": 1.1
}</patch>
</scheme>
