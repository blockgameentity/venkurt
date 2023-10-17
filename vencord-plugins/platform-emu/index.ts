import { definePluginSettings } from "@api/Settings";
import definePlugin, { OptionType } from "@utils/types";

const settings = definePluginSettings({
    platform: {
        description: "Platform to emulate",
        type: OptionType.SELECT,
        options: [
            { label: "Windows", value: "win32|Discord Client", default: true },
            { label: "MacOS", value: "darwin|Discord Client", default: false },
            { label: "Linux", value: "linux|Discord Client", default: false },
            { label: "TempleOS", value: "temple|Discord Client", default: false },
            { label: "Web", value: "web|Discord Web", default: false },
            { label: "Android", value: "android|Discord Android", default: false },
            { label: "iOS", value: "ios|Discord iOS", default: false }
        ],
        restartNeeded: true
    }
});

export default definePlugin({
    name: "platform emulator",
    description: "tricks discord into thinking you're on e.g. phone.",
    authors: [
        {
            id: 526331463709360141n,
            name: "desu"
        }
    ],
    settings,
    patches: [
        {
            find: "browser:\"Discord Client\"",
            replacement: {
                match: /os:([^,]+),browser:"Discord Client"/,
                replace: "os:$self.getOs(),browser:$self.getBrowser()"
            }
        },
    ],
    getOs() {
        return settings.store.platform.split("|")[0];
    },
    getBrowser() {
        return settings.store.platform.split("|")[1];
    }
});
